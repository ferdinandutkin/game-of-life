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
        public ReactiveGame Model { get; set; }

        public ICommand NextStateCommand { get; private set; }


        public  ICommand ClearCommand { get; private set; }

        public ObservableCollection<ObservableCollection<TileViewModel>> Tiles
        {
            get;
            set;
        } = new();


        void MapFieldToBindingTable()
        {
            for (int i = 0; i < Model.Field.Table.GetLength(0); i++)
            {
                Tiles.Add(new());
                for (int j = 0; j < Model.Field.Table.GetLength(1); j++)
                {
                   
                    Tiles[i].Add(new TileViewModel(Model.Field.Table[i, j] as ReactiveTile));

                }
            }
        }


        void InitField()
        {

            for (int i = 0; i < Model.Field.Table.GetLength(0); i++)
            {
                
                for (int j = 0; j < Model.Field.Table.GetLength(1); j++)
                {
               

                    Model.Field.Table[i, j] = new ReactiveTile() ;

                   

                }
            }
        }

        private void InitCommands()
        {
            NextStateCommand = ReactiveCommand.Create(Model.NextState);

            ClearCommand = ReactiveCommand.Create(Model.Field.Clear);
        }


        public GameViewModel()  
        {
            Model = new ReactiveGame( new ReactiveField(new ReactiveTile[20, 20]));

            InitField();

            MapFieldToBindingTable();

            InitCommands();

        }

       
      
        public GameViewModel(ReactiveGame model)
        {

            Model = model;

            MapFieldToBindingTable();

            InitCommands();

           


        }
    }
}
