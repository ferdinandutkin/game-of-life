

using Core.Models;
using ReactiveCore.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace ReactiveCore.ViewModels
{
    public class GameViewModel : ViewModelBase, IActivatableViewModel
    {
        [Reactive]
        public ReactiveGame Model { get; set; }

        [Reactive]
        public bool IsRunning { get; set; }

        public ReactiveCommand<Unit, Unit> NextStateCommand { get; private set; }


        public ReactiveCommand<Unit, Unit> ClearCommand { get; private set; }

        public ReactiveCommand<Unit, Unit> ToggleRunningCommand { get; private set; }


        public ObservableCollection<ObservableCollection<TileViewModel>> Tiles
        {
            get;
            set;
        } = new();

 

        public ViewModelActivator Activator { get; } = new ViewModelActivator();

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


                    Model.Field.Table[i, j] = new ReactiveTile();



                }
            }
        }


        void ToggleRunning()
        {
            IsRunning = !IsRunning;
        }


        private void InitCommands()
        {
            NextStateCommand =  ReactiveCommand.Create(Model.NextState);

            ClearCommand = ReactiveCommand.Create(Model.Field.Clear);

            ToggleRunningCommand = ReactiveCommand.Create(ToggleRunning);

            this.WhenActivated(d =>
               Observable.Interval(TimeSpan.FromSeconds(1), RxApp.MainThreadScheduler)
               .Where(_ => IsRunning)
               .Select(_ => Unit.Default)
               .InvokeCommand(NextStateCommand)
               .DisposeWith(d));


        }


        public GameViewModel()
        {
            Model = new ReactiveGame(new ReactiveField(new ReactiveTile[20, 20]));

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
