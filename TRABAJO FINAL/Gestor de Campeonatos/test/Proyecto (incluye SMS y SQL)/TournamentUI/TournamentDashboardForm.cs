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
using TournamentLibrary.Models;

namespace TournamentUI
{
    public partial class TournamentDashboardForm : Form
    {
        private List<TournamentModel> tournaments = GlobalConfig.Connection.GetTournament_All();              

        public TournamentDashboardForm()
        {
            InitializeComponent();

            WireUpLists();                  
        }

        private void WireUpLists()
        {
            loadExistingTournamentDropDown.DataSource = tournaments;                
            loadExistingTournamentDropDown.DisplayMember = "TournamentName";        
        }

        private void CreateTournamentButton_Click(object sender, EventArgs e)
        {
            CreateTournamentForm frm = new CreateTournamentForm();
            frm.Show();
        }

        private void LoadTournamentButton_Click(object sender, EventArgs e)
        {
            TournamentModel tm = (TournamentModel)loadExistingTournamentDropDown.SelectedItem;
            TournamentViewerForm frm = new TournamentViewerForm(tm);
            frm.Show();
        }
    }
}
