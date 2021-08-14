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
    public class ReactiveField : ReactiveObject, IField
    {
        [Reactive]
        public ITile[,] Table { get; set; }

        public ReactiveField(ReactiveTile[,] table)
        {
            Table = table;
        }
    } 
}
