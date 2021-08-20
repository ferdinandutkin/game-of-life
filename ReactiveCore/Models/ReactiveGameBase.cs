using Core.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveCore.Models
{
    public class ReactiveGameBase : ReactiveObject, IGame
    {

        [Reactive]
        public IField Field { get; set; }

        public ReactiveGameBase(ReactiveField field) => Field = field;

    }

}
