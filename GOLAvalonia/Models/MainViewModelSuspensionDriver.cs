using GOLAvalonia.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Models;
using ReactiveCore.Models;

namespace GOLAvalonia.Models
{
    class MainViewModelSuspensionDriver : ISuspensionDriver
    {



        private static readonly JsonSerializerOptions options = new() { Converters = { new MainViewModelConverter() } };
        private readonly string _filePath;
        public MainViewModelSuspensionDriver(string filePath)
        {
            _filePath = filePath;
        }
        public IObservable<Unit> InvalidateState()
        {

            if (File.Exists(_filePath))
                File.Delete(_filePath);
            return Observable.Return(Unit.Default);

        }

        public IObservable<object> LoadState()
        {
            if (File.Exists(_filePath))
            {
                var serialized = File.ReadAllText(_filePath);
                return Observable.Return<object>(JsonSerializer.Deserialize<MainWindowViewModel>(serialized, options));
            }

            return Observable.Return<object>(null);
        }

        public IObservable<Unit> SaveState(object state)
        {
             
          
            var serialized = JsonSerializer.Serialize(state, typeof(MainWindowViewModel), options);
            //дженерик-перегрузка какая-то сломанная

            File.WriteAllText(_filePath, serialized);

            return Observable.Return(Unit.Default);
        }
    }
}
