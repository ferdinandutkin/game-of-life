using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace GOLAvalonia.Models
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

