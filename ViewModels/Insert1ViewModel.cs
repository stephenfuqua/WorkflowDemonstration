using System;

namespace WorkflowDemonstration.ViewModels
{
    public class Input1ViewModel : BaseViewModel
    {

        public string Input1Field1
        {
            get
            {
                return this.WorkflowState.Input1Field1;
            }
            set
            {
                this.WorkflowState.Input1Field1 = value;
                NotifyOfPropertyChange(() => Input1Field1);
            }
        }
        


        public string Input1Field2
        {
            get
            {
                return this.WorkflowState.Input1Field2;
            }
            set
            {
                this.WorkflowState.Input1Field2 = value;
                NotifyOfPropertyChange(() => Input1Field2);
            }
        }


        
        public DateTime Input1Field3
        {
            get
            {
                return this.WorkflowState.Input1Field3;
            }
            set
            {
                this.WorkflowState.Input1Field3 = value;
                NotifyOfPropertyChange(() => Input1Field3);
            }
        }



        public Input1ViewModel(Models.WorkflowState workflowState)
            : base(workflowState)
        {
            this.DisplayName = "Screen 1 - Input";
        }



        public void Next()
        {
            this.NextTransition = Models.StateTransition.Input1Success;
            this.TryClose();
        }
    }
}
