﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TournamentLibrary.Models;

namespace TournamentLibrary.Logic
{
    public static class TournamentLogic     
    {
        public static void UpdateTournamentResults(TournamentModel model)
        {
            int startingRound = model.CheckCurrentRound();
            
            List<MatchupModel> toScore = new List<MatchupModel>();  

            foreach (List<MatchupModel> round in model.Rounds)      
            {
                foreach (MatchupModel roundMatchup in round)        
                {
                    if ((roundMatchup.Entries.Any(x => x.Score != 0) || roundMatchup.Entries.Count == 1))
                    {                                                                                   
                        toScore.Add(roundMatchup);              
                    }
                }
            }

            MarkWinnerInMatchups(toScore);                      

            AdvanceWinners(toScore, model);                                                    

            toScore.ForEach(x => GlobalConfig.Connection.UpdateMatchup(x));

            int endingRound = model.CheckCurrentRound();
            if (endingRound > startingRound)
            {
                model.AlertUsersToNewRound();   
            }
        }

        public static void AlertUsersToNewRound(this TournamentModel model)     
        {                                                                       
            int currentRoundNumber = model.CheckCurrentRound();
            List<MatchupModel> currentRound = model.Rounds.Where(x => x.First().MatchupRound == currentRoundNumber).First();

            foreach (MatchupModel matchup in currentRound)
            {
                foreach (MatchupEntryModel me in matchup.Entries)
                {
                    foreach (PersonModel p in me.TeamCompeting.TeamMembers)
                    {
                        AlertPersonToNewRound(p, me.TeamCompeting.TeamName, matchup.Entries.Where(x => x.TeamCompeting != me.TeamCompeting).FirstOrDefault());
                    }
                }
            }
        }

        private static void AlertPersonToNewRound(PersonModel p, string teamName, MatchupEntryModel competitor)
        {   
            if (p.EmailAddress.Length > 0)     
            {
                string to = "";
                string subject = "";
                StringBuilder body = new StringBuilder();

                if (competitor != null)
                {
                    subject = $"You have a new matchup with { competitor.TeamCompeting.TeamName }";

                    body.AppendLine("<h1>You have a new matchup</h1>");
                    body.Append("<p><strong>Competitor: </strong>");
                    body.Append($"{ competitor.TeamCompeting.TeamName }</p>");
                    body.AppendLine("Have a great time!");
                    body.AppendLine("<br />");
                    body.AppendLine("~Joris from the TournamentApp");
                }
                else
                {
                    subject = "You have a bye matchup this round";

                    body.AppendLine("<h1>You don't have an opponent this round</h1>");
                    body.AppendLine("Enjoy your round off!");
                    body.AppendLine("<br />");
                    body.AppendLine("~Joris from the TournamentApp");
                }

                to = p.EmailAddress;

                EmailLogic.SendEmail(to, subject, body.ToString());
            }

            if (p.CellphoneNumber.Length > 0 && competitor != null)
            {   
                SMSLogic.SendSMSMessage($"You have a new matchup with { competitor.TeamCompeting.TeamName }");
            }    
        }

        private static int CheckCurrentRound(this TournamentModel model)
        {
            int output = 1;                                     

            foreach (List<MatchupModel> round in model.Rounds)  
            {
                if (round.All(x => x.Winner != null ))          
                {                                               
                    output += 1;
                }
                else
                {
                    return output;
                }
            }

            CompleteTournament(model);

            return output - 1;
        }

        private static void CompleteTournament(TournamentModel model)
        {
            GlobalConfig.Connection.CompleteTournament(model);          

            TeamModel winners = model.Rounds.Last().First().Winner;
            decimal winnerPrize = 0;
            
            if (model.Prizes.Count > 0)
            {
                decimal totalIncome = model.EnteredTeams.Count * model.EntryFee;    
                PrizeModel firstPlacePrize = model.Prizes.Where(x => x.PlaceNumber == 1).FirstOrDefault();

                if (firstPlacePrize != null)
                {
                    winnerPrize = firstPlacePrize.CalculatePrizePayout(totalIncome);
                }
            }

            string subject = "";
            StringBuilder body = new StringBuilder();

            subject = $"In { model.TournamentName }, { winners.TeamName } has won!";

            body.AppendLine("<h1>We have a WINNER!</h1>");
            body.AppendLine("<p>Congratulations to our winner on a great tournament.</p>");
            body.AppendLine("<br />");

            if (winnerPrize > 0)
            {
                body.AppendLine($"<p>{ winners.TeamName } will receive €{ winnerPrize }</p>");
            }

            body.AppendLine("Thanks for a great tournament everyone!");
            body.AppendLine("<br />");
            body.AppendLine("~Joris from the TournamentApp");

            List<string> bcc = new List<string>();

            foreach (TeamModel t in model.EnteredTeams)
            {
                foreach (PersonModel p in t.TeamMembers)
                {
                    if (p.EmailAddress.Length > 0)
                    {
                        bcc.Add(p.EmailAddress); 
                    }
                }
            }
            
            EmailLogic.SendEmail(new List<string>(), bcc, subject, body.ToString());
            SMSLogic.SendSMSMessage($"We have a winner: { winners.TeamName }!");

            model.CompleteTournament(); 
        }

        private static decimal CalculatePrizePayout(this PrizeModel prize, decimal totalIncome)
        {
            decimal output = 0;

            if (prize.PrizeAmount > 0)
            {
                output = prize.PrizeAmount;
            }
            else
            {
                output = Decimal.Multiply(totalIncome, Convert.ToDecimal(prize.PrizePercentage / 100)); 
            }

            return output;
        }

        private static void AdvanceWinners(List<MatchupModel> models, TournamentModel tournament)
        {
            foreach (MatchupModel m in models)
            {
                foreach (List<MatchupModel> round in tournament.Rounds)
                {
                    foreach (MatchupModel roundMatchup in round)
                    {
                        foreach (MatchupEntryModel me in roundMatchup.Entries)
                        {
                            if (me.ParentMatchup != null)
                            {
                                if (me.ParentMatchup.Id == m.Id)
                                {
                                    me.TeamCompeting = m.Winner;

                                    GlobalConfig.Connection.UpdateMatchup(roundMatchup);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void MarkWinnerInMatchups(List<MatchupModel> models)
        {
            string greaterWins = GlobalConfig.AppKeyLookup("greaterWins");          

            foreach (MatchupModel m in models)                                      
            {
                if (m.Entries.Count == 1)                                           
                {                                                                   
                    m.Winner = m.Entries[0].TeamCompeting;                          
                    continue;                                                       
                }
                
                if (greaterWins == "0")                                             
                {
                    if (m.Entries[0].Score < m.Entries[1].Score)                    
                    {
                        m.Winner = m.Entries[0].TeamCompeting;                      
                    }
                    else if (m.Entries[1].Score < m.Entries[0].Score)               
                    {
                        m.Winner = m.Entries[1].TeamCompeting;                      
                    }
                    else
                    {
                        throw new Exception("This application does not allow ties."); 
                    }
                }
                else                                                                
                {
                    if (m.Entries[0].Score > m.Entries[1].Score)                    
                    {
                        m.Winner = m.Entries[0].TeamCompeting;                      
                    }
                    else if (m.Entries[1].Score > m.Entries[0].Score)               
                    {
                        m.Winner = m.Entries[1].TeamCompeting;                      
                    }
                    else
                    {
                        throw new Exception("This application does not allow ties.");
                    }
                } 
            }
        }

        public static void CreateRounds(TournamentModel model)
        {
            List<TeamModel> randomizedTeams = RandomizeTeamOrder(model.EnteredTeams);

            int rounds = FindNumberOfRounds(randomizedTeams.Count);
            int byes = NumberOfByes(rounds, randomizedTeams.Count);

            model.Rounds.Add(CreateFirstRound(byes, randomizedTeams));

            CreateOtherRounds(model, rounds);
        }

        private static void CreateOtherRounds(TournamentModel model, int rounds)
        {
            int round = 2;                                              

            List<MatchupModel> previousRound = model.Rounds[0];         
                                                                        
            List<MatchupModel> currentRound = new List<MatchupModel>(); 
                                                                        
            MatchupModel currentMatchup = new MatchupModel();           

            while (round <= rounds)
            {
                foreach (MatchupModel match in previousRound)
                {
                    currentMatchup.Entries.Add(new MatchupEntryModel { ParentMatchup = match });    

                    if (currentMatchup.Entries.Count > 1)
                    {
                        currentMatchup.MatchupRound = round;
                        currentRound.Add(currentMatchup);
                        currentMatchup = new MatchupModel();
                    }
                }

                model.Rounds.Add(currentRound);             
                                                            
                previousRound = currentRound;               
                currentRound = new List<MatchupModel>();    
                round += 1;                                 
            }
        }

        private static List<MatchupModel> CreateFirstRound(int byes, List<TeamModel> teams)
        {
            List<MatchupModel> output = new List<MatchupModel>();   
            
            MatchupModel currentMatchup = new MatchupModel();       
            
            foreach (TeamModel team in teams)                      
            {
                currentMatchup.Entries.Add(new MatchupEntryModel { TeamCompeting = team }); 

                if (byes > 0 || currentMatchup.Entries.Count > 1)
                {
                    currentMatchup.MatchupRound = 1;
                    output.Add(currentMatchup);
                    currentMatchup = new MatchupModel();    

                    if (byes > 0)                           
                    {                                       
                        byes -= 1;                          
                    }
                }
            }

            return output;
        }
        
        private static int FindNumberOfRounds(int teamCount)
        {
            int output = 1;
            int val = 2;

            while (val < teamCount)
            {
                output += 1;
                val *= 2;
            }

            return output;
        }

        private static int NumberOfByes(int rounds, int numberOfTeams)
        {
            int output = 0;         
            int totalTeams = 1;     

            for (int i = 1; i <= rounds; i++)   
            {                                   
                totalTeams *= 2;                
            }

            output = totalTeams - numberOfTeams;    

            return output;
        }

        private static List<TeamModel> RandomizeTeamOrder(List<TeamModel> teams)
        {
            return teams.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}
