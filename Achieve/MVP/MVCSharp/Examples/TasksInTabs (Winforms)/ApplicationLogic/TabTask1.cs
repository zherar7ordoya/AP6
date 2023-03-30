﻿using System;
using System.Collections.Generic;
using System.Text;
using MVCSharp.Core.Tasks;
using MVCSharp.Core.Configuration.Tasks;
using MVCSharp.Core;

namespace MVCSharp.Examples.TasksInTabs.ApplicationLogic
{
    public class TabTask1 : TaskBase
    {
        [IPoint(typeof(ControllerBase), View2)]
        public const string View1 = "View1";

        [IPoint(typeof(ControllerBase))]
        public const string View2 = "View2";

        private int taskStartTimes;

        public int TaskStartTimes
        {
            get { return taskStartTimes; }
        }

        public override void OnStart(object param)
        {
            taskStartTimes++;
            Navigator.ActivateView(View1);
        }
    }
}
