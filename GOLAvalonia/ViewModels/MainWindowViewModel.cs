using ReactiveCore.ViewModels;
using ReactiveUI.Fody.Helpers;

namespace GOLAvalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        [Reactive] 
        public GameViewModel Game { get; set; } = new();
  
    }
}
