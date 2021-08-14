using Core.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ReactiveCore.Models
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
