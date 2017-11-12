namespace WorkflowDemonstration.ViewModels
{
    public class Question2ViewModel : BaseViewModel
    {

        public bool Question1
        {
            get
            {
                return this.WorkflowState.Question1;
            }
            set
            {
                this.WorkflowState.Question1 = value;
                NotifyOfPropertyChange(() => Question1);
                NotifyOfPropertyChange(() => QuestionButtonLabel);
            }
        }

        public string QuestionButtonLabel
        {
            get
            {
                if (Question1)
                {
                    return "Yes";
                }
                else
                {
                    return "No";
                }
            }
        }


        public Question2ViewModel(Models.WorkflowState workflowState)
            : base(workflowState)
        {
            this.DisplayName = "Screen 2 - Question";
        }


        public void Next()
        {
            if (Question1)
            {
                this.NextTransition = Models.StateTransition.Option1;
            }
            else
            {
                this.NextTransition = Models.StateTransition.Option2;
            }
            this.TryClose();
        }
    }
}
