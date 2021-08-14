using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Core.Models;
using ReactiveCore.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ReactiveCore.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        [Reactive] 
        private ReactiveGame Model { get; set; }

        public ICommand NextStateCommand { get; }


        public  ICommand ClearCommand { get; }

        public ObservableCollection<ObservableCollection<TileViewModel>> Tiles
        {
            get;
            set;
        } = new();

        void InitBindingTable()
        {
            for (int i = 0; i < Model.Field.Table.GetLength(0); i++)
            {
                Tiles.Add(new());
                for (int j = 0; j < Model.Field.Table.GetLength(1); j++)
                {
                    var cell   = new ReactiveTile() {IsAlive = new Random().Next(1, 4) == 2};

                    Model.Field.Table[i, j] = cell;

                    Tiles[i].Add(new TileViewModel(cell));

                }
            }
        }

        
        public GameViewModel(ReactiveGame model = null)
        {
            Model = model ?? 
                    new ReactiveGame(
                        new ReactiveField(
                            new ReactiveTile[20, 20]));

            InitBindingTable();

            NextStateCommand = ReactiveCommand.Create(Model.NextState);

            ClearCommand = ReactiveCommand.Create(Model.Field.Clear);


        }
    }
}
