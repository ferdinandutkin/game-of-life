using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.ReactiveUI;
using GOLAvalonia.Models;
using GOLAvalonia.ViewModels;
using ReactiveCore.ViewModels;
using ReactiveUI;

namespace GOLAvalonia.Views
{
    public partial class TileView : ReactiveUserControl<TileViewModel>
    {
        public TileView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.OneWayBind(ViewModel, m => m.Model.IsAlive, v => v.CellStateRectangle.Fill, state => new SolidColorBrush(state ? Colors.Gray : Colors.White)).DisposeWith(d);
                
              
                
                CellStateRectangle.GetObservable(TappedEvent)
                    .Select(_ => Unit.Default)
                    .InvokeCommand(this, view => view!.ViewModel!.ToggleStateCommand)
                    .DisposeWith(d);


            });
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
