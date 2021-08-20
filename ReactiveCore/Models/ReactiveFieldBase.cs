using Core.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveCore.Models
{
    public class ReactiveFieldBase : ReactiveObject, IField
    {

        public ITile[,] Table { get; set; }

        public ReactiveFieldBase(ReactiveTile[,] table)
        {
            Table = table;
        }
    }
}

