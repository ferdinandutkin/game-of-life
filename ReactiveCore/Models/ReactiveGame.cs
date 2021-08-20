using Core.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ReactiveCore.Models
{
    public class ReactiveGame : ReactiveGameBase
    {
 
        public new ReactiveField Field 
        { 
            get => base.Field as ReactiveField;
            set => base.Field = value; 
        }



        public ReactiveGame(ReactiveField field) : base(field) => Field = field;

    }
}

