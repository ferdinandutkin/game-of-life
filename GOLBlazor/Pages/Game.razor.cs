using Microsoft.AspNetCore.Components;
using ReactiveCore.ViewModels;

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

        
        public Game()
        {
             
             
        }
    }
}
