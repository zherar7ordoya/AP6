﻿using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.Models;
using TournamentLibrary.DataAccess.TextHelpers;    
using System.Linq;
using TournamentLibrary.Logic;

namespace TournamentLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        public void CreatePerson(PersonModel model)             
        {
            List<PersonModel> people = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();   

            int currentId = 1;                                                  
            
            if (people.Count > 0)                                               
            {
                int highestId = people.OrderByDescending(x => x.Id).First().Id; 
                currentId = highestId + 1;                                      
            }

            model.Id = currentId;                                               
            people.Add(model);                                                  
            people.SaveToPeopleFile();                              
        }

        public void CreatePrize(PrizeModel model)               
        {
            List<PrizeModel> prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels(); 

            int currentId = 1;
            if (prizes.Count > 0)
            {
                int highestId = prizes.OrderByDescending(x => x.Id).First().Id;
                currentId = highestId + 1;                                      
            }

            model.Id = currentId;       
            prizes.Add(model);
            prizes.SaveToPrizeFile();                               
        }

        public void CreateTeam(TeamModel model)                 
        {
            List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();  

            int currentId = 1;                                                  
                                                                                
            if (teams.Count > 0)                                                
            {
                int highestId = teams.OrderByDescending(x => x.Id).First().Id;  
                currentId = highestId + 1;                                      
            }                                                                   

            model.Id = currentId;                                               
            teams.Add(model);                                                   
            teams.SaveToTeamFile();                                 
        }

        public void CreateTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels();  

            int currentId = 1;
            if (tournaments.Count > 0)
            {
                int highestId = tournaments.OrderByDescending(x => x.Id).First().Id;
                currentId = highestId + 1;
            }

            model.Id = currentId;
            model.SaveRoundsToFile();
            tournaments.Add(model);
            tournaments.SaveToTournamentFile();                     
            TournamentLogic.UpdateTournamentResults(model);     
        }

        public List<PersonModel> GetPerson_All()
        {
            return GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();          
        }

        public List<TeamModel> GetTeam_All()
        {
            return GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();               
        }

        public List<TournamentModel> GetTournament_All()
        {
            return GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels();   
        }

        public void UpdateMatchup(MatchupModel model)
        {
            model.UpdateMatchupToFile();
        }

        public void CompleteTournament(TournamentModel model)
        {
            List <TournamentModel> tournaments = GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels();

            tournaments.Remove(model);
            tournaments.SaveToTournamentFile();
        }
    }
}
