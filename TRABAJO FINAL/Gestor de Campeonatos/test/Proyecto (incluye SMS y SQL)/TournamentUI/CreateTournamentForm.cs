﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentLibrary;
using TournamentLibrary.Logic;
using TournamentLibrary.Models;

namespace TournamentUI
{
    public partial class CreateTournamentForm : Form, IPrizeRequester, ITeamRequester   
    {
        private List<TeamModel> availableTeams = GlobalConfig.Connection.GetTeam_All(); 
        private List<TeamModel> selectedTeams = new List<TeamModel>();                  
        private List<PrizeModel> selectedPrizes = new List<PrizeModel>();               
                                                                                
        public CreateTournamentForm()
        {
            InitializeComponent();

            WireUpLists();              
        }

        private void WireUpLists()
        {
            selectTeamDropDown.DataSource = null;               
            selectTeamDropDown.DataSource = availableTeams;
            selectTeamDropDown.DisplayMember = "TeamName";      

            tournamentTeamsListBox.DataSource = null;               
            tournamentTeamsListBox.DataSource = selectedTeams;      
            tournamentTeamsListBox.DisplayMember = "TeamName";      

            prizesListBox.DataSource = null;
            prizesListBox.DataSource = selectedPrizes;
            prizesListBox.DisplayMember = "PlaceName";
        }

        private void AddTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = (TeamModel)selectTeamDropDown.SelectedItem;   
                                                                        
            if (t != null)                                              
            {                                                           
                availableTeams.Remove(t);                               
                selectedTeams.Add(t);                                   

                WireUpLists();                                          
            }
        }

        private void CreatePrizeButton_Click(object sender, EventArgs e)
        {
            CreatePrizeForm frm = new CreatePrizeForm(this);                
            frm.Show();
        }

        public void PrizeComplete(PrizeModel model)
        {
            selectedPrizes.Add(model);              
            
            WireUpLists();                          
        }

        public void TeamComplete(TeamModel model)
        {
            selectedTeams.Add(model);               
            
            WireUpLists();                          
        }

        private void CreateNewTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm frm = new CreateTeamForm(this);  
            frm.Show();                                     
        }

        private void RemoveSelectedPlayerButton_Click(object sender, EventArgs e)
        {
            TeamModel t = (TeamModel)tournamentTeamsListBox.SelectedItem;           

            if (t != null)                      
            {       
                selectedTeams.Remove(t);        
                availableTeams.Add(t);          

                WireUpLists();                  
            }
        }

        private void RemoveSelectedPrizeButton_Click(object sender, EventArgs e)
        {
            PrizeModel p = (PrizeModel)prizesListBox.SelectedItem;

            if (p != null)
            {
                selectedPrizes.Remove(p);

                WireUpLists();
            }
        }
 
        private void CreateTournamentButton_Click(object sender, EventArgs e)
        {
            decimal fee = 0;                                                        
            bool feeAcceptable = decimal.TryParse(entryFeeValue.Text, out fee);     

            if (feeAcceptable == false)
            {
                MessageBox.Show("You need to enter a valid Entry Fee", 
                    "Invalid Fee", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;                     
            }

            TournamentModel tm = new TournamentModel();
            tm.TournamentName = tournamentNameValue.Text;   
            tm.EntryFee = fee;                              
            tm.EnteredTeams = selectedTeams;
            tm.Prizes = selectedPrizes;

            TournamentLogic.CreateRounds(tm);   
            GlobalConfig.Connection.CreateTournament(tm);
            tm.AlertUsersToNewRound();

            TournamentViewerForm frm = new TournamentViewerForm(tm);
            frm.Show();
            this.Close();
        }
    }
}
