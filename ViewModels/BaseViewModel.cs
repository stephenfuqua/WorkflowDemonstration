﻿using Caliburn.Micro;
using System;
using WorkflowDemonstration.Models;

namespace WorkflowDemonstration.ViewModels
{
    public class BaseViewModel : Screen
    {
        public WorkflowState WorkflowState { get; private set; }

        public StateTransition NextTransition { get; protected set; }


        public BaseViewModel(WorkflowState workflowState)
        {
            if (workflowState == null)
            {
                throw new ArgumentNullException("workflowState");
            }

            this.WorkflowState = workflowState;
        }


        public void Cancel()
        {
            NextTransition = StateTransition.Cancel;
            WorkflowState = new WorkflowState();
            this.TryClose();
        }
    }
}
