using System.Reflection;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using GOLAvalonia.Models;
using GOLAvalonia.ViewModels;
using GOLAvalonia.Views;
using ReactiveUI;
using Splat;

namespace GOLAvalonia
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetExecutingAssembly());

            Locator.CurrentMutable.Register(() => new MainWindowViewModel());
           

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {

                var suspension = new AutoSuspendHelper(ApplicationLifetime);
                RxApp.SuspensionHost.CreateNewAppState = () => Locator.Current.GetService<MainWindowViewModel>() ?? new MainWindowViewModel();
                RxApp.SuspensionHost.SetupDefaultSuspendResume(new MainViewModelSuspensionDriver("appstate.json"));
                suspension.OnFrameworkInitializationCompleted();

                // Load the saved view model state.
                var state = RxApp.SuspensionHost.GetAppState<MainWindowViewModel>();

                desktop.MainWindow = new MainWindow
                {
                    DataContext = state,
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
