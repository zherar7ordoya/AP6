﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using MVCSharp.Winforms;
using MVCSharp.Core.Configuration;
using MVCSharp.Winforms.Configuration;
using MVCSharp.Core.Views;
using System.Collections;
using MVCSharp.Core.Configuration.Views;

namespace MVCSharp.Examples.TasksInTabs.Presentation
{
    public class TasksInTabsViewsManager : WinformsViewsManager
    {
        static MainForm mainFrm;

        protected override void ActivateUserControlView(IView view)
        {
            base.ActivateUserControlView(view);
            (view as Control).BringToFront();
        }

        protected override void InitializeUserControlView(UserControl userControlView)
        {
            base.InitializeUserControlView(userControlView);
            mainFrm.CurrentTabPage.Controls.Add(userControlView);
            userControlView.Dock = DockStyle.Fill;
        }

        protected override void InitializeFormView(Form form, WinformsViewInfo viewInf)
        {
            base.InitializeFormView(form, viewInf);
            mainFrm = form as MainForm;
        }

        new public static MVCConfiguration GetDefaultConfig()
        {
            MVCConfiguration defaultConf = WinformsViewsManager.GetDefaultConfig();
            defaultConf.ViewsAssembly = Assembly.GetCallingAssembly();
            defaultConf.ViewsManagerType = typeof(TasksInTabsViewsManager);
            return defaultConf;
        }
    }
}
