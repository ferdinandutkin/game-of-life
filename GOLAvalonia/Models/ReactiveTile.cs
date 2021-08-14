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
    public class ReactiveTile : ReactiveObject, ITile
    {

        [Reactive]
        public bool IsAlive { get; set; }
    }
}
