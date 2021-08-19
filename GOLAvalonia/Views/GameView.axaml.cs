using System.Reactive.Disposables;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using GOLAvalonia.ViewModels;
using ReactiveCore.ViewModels;
using ReactiveUI;

namespace GOLAvalonia.Views
{
    public partial class GameView : ReactiveUserControl<GameViewModel>
    {
        public GameView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
                {
                    this.BindCommand(ViewModel, vm => vm.NextStateCommand, v => v.NextStateButton).DisposeWith(d);
                    this.BindCommand(ViewModel, vm => vm.ClearCommand, v => v.ClearButton).DisposeWith(d);
                    this.BindCommand(ViewModel, vm => vm.ToggleRunningCommand, v => v.ToggleRunning).DisposeWith(d);

                }
              );

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
