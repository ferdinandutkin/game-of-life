using System.Windows.Input;
using ReactiveCore.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ReactiveCore.ViewModels
{
    public class TileViewModel : ViewModelBase
    {
        [Reactive]
        public ReactiveTile Model { get; set; }

        public ICommand ToggleStateCommand { get; }

        private void ToggleState() => Model.IsAlive = !Model.IsAlive;


        public TileViewModel(ReactiveTile model)
        {
            Model = model;
            ToggleStateCommand = ReactiveCommand.Create(ToggleState);
        }
    }
}
