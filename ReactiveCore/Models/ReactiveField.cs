using Core.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ReactiveCore.Models
{
    public class ReactiveField : ReactiveFieldBase
    {
       
        public new ReactiveTile[,] Table 
        { 
            get => base.Table as ReactiveTile[,]; 
            set => base.Table = value; 
        }

        public ReactiveField(ReactiveTile[,] table) : base(table) => Table = table;
    } 
}
