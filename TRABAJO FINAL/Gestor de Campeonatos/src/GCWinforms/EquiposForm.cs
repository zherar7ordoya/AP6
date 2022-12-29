﻿using ReaLTaiizor.Forms;
using ReaLTaiizor.Manager;

namespace GCWinforms
{
    public partial class EquiposForm : MaterialForm
    {
        public EquiposForm(MaterialSkinManager msm)
        {
            InitializeComponent();

            // --- Material Skin ---------------
            MaterialSkinManager MSManager = msm;
            MSManager.AddFormToManage(this);
            // ---------------------------------
        }
    }
}