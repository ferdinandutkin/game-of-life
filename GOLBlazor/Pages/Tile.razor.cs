using System.Reactive.Disposables;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ReactiveCore.ViewModels;
using ReactiveUI;

namespace GOLBlazor.Pages
{
    public partial class Tile 
    {
        public string Color
        {
            get => _color;
            set
            {
                _color = value;
                StateHasChanged();
            }
        }



        [Parameter]
        public TileViewModel TileViewModel { get; set; }

        protected override Task OnParametersSetAsync()
        {
            ViewModel = TileViewModel;
            return base.OnParametersSetAsync();

           
        }

        private string _color;


     
        public Tile()
        {
            this.WhenActivated(d =>
            {
                this.OneWayBind(ViewModel, vm => vm.Model.IsAlive, v => v.Color,alive => alive? "gray" : "white").DisposeWith(d);
            });
        }
    }
}
