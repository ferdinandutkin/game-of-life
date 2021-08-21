using Microsoft.AspNetCore.Components;
using ReactiveCore.ViewModels;
using ReactiveUI;
using System.Collections.Generic;
using System.Reactive.Disposables;

namespace GOLBlazor.Pages
{
    public partial class Game : ReactiveUI.Blazor.ReactiveComponentBase<GameViewModel>
    {
        [Inject]

        public GameViewModel GameViewModel
        {
            get => ViewModel;
            set => ViewModel = value;
        }

        bool IsDisabled
        {
            get;
            set;
        }

        public Game()
        {
            this.WhenActivated(d =>
            {

                GameViewModel.Activator.Activate().DisposeWith(d);
                this.OneWayBind(ViewModel, vm => vm.IsRunning, v => v.IsDisabled).DisposeWith(d);
            });
        }

    }
}
