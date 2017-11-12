using System.Text;

namespace WorkflowDemonstration.ViewModels
{
    public class Finalize4ViewModel : BaseViewModel
    {
        private string m_results;

        public string Results
        {
            get
            {
                return this.m_results;
            }
            set
            {
                this.m_results = value;
                NotifyOfPropertyChange(() => Results);
            }
        }
        
        
        public Finalize4ViewModel(Models.WorkflowState workflowState)
            : base(workflowState)
        {
            this.DisplayName = "Screen 4 - Finalize";

            formatResults();
        }

        private void formatResults()
        {
            var builder = new StringBuilder();
            builder.AppendLine("You've finished your task! Results:");
            builder.AppendLine("Input 1/1: " + this.WorkflowState.Input1Field1);
            builder.AppendLine("Input 1/2: " + this.WorkflowState.Input1Field2);
            builder.AppendLine("Input 1/3: " + this.WorkflowState.Input1Field3);
            builder.AppendLine("Question: " + this.WorkflowState.Question1);
            if (this.WorkflowState.Question1)
            {
                builder.AppendLine("Input 3/1: " + this.WorkflowState.Input3Field1);
                builder.AppendLine("Input 3/2: " + this.WorkflowState.Input3Field2);
            }

            Results = builder.ToString();
        }


    }
}
