using Caliburn.Micro;
using System;
using System.Collections.Generic;
using WorkflowDemonstration.Models;

namespace WorkflowDemonstration.ViewModels
{
    public class ApplicationControllerViewModel : Conductor<IScreen>.Collection.OneActive
    {

        public ApplicationControllerViewModel()
        {
            initializeMap();

            activateFirstScreen();
        }

        private void activateFirstScreen()
        {
            var screen = new Input1ViewModel(new WorkflowState());
            this.ActivateItem(screen);
        }


        private void initializeMap()
        {
            TransitionMap.Add<Input1ViewModel, Question2ViewModel>(StateTransition.Input1Success);
            TransitionMap.Add<Input1ViewModel, Input1ViewModel>(StateTransition.Cancel);

            TransitionMap.Add<Question2ViewModel, Input3ViewModel>(StateTransition.Option1);
            TransitionMap.Add<Question2ViewModel, Finalize4ViewModel>(StateTransition.Option2);
            TransitionMap.Add<Question2ViewModel, Input1ViewModel>(StateTransition.Cancel);

            TransitionMap.Add<Input3ViewModel, Finalize4ViewModel>(StateTransition.Input3Success);
            TransitionMap.Add<Input3ViewModel, Input1ViewModel>(StateTransition.Cancel);

            TransitionMap.Add<Finalize4ViewModel, Input1ViewModel>(StateTransition.Cancel);
        }


        protected override IScreen DetermineNextItemToActivate(IList<IScreen> list, int lastIndex)
        {
            var theScreenThatJustClosed = list[lastIndex] as BaseViewModel;
            var state = theScreenThatJustClosed.WorkflowState;

            var nextScreenType = TransitionMap.GetNextScreenType(theScreenThatJustClosed);

            var nextScreen = Activator.CreateInstance(nextScreenType, state);

            return nextScreen as IScreen;
        }

    }
}
