using Core.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ReactiveCore.Models
{
    public class ReactiveTile : ReactiveObject, ITile
    {

        [Reactive]
        public bool IsAlive { get; set; }
    }
}
