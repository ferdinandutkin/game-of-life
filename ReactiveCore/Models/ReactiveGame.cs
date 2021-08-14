using Core.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ReactiveCore.Models
{
    public class ReactiveGame : ReactiveObject, IGame
    {
        [Reactive]
        public IField Field { get; set; }

        public ReactiveGame(ReactiveField field)
        {
            Field = field;
        }

    }
}

