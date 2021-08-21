using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ReactiveCore.ViewModels;
using System.Reactive.Concurrency;
using Splat;

namespace GOLBlazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
 
            Locator.CurrentMutable.RegisterConstant<IScheduler>(ThreadPoolScheduler.Instance);

            builder.Services.AddScoped(sp => new GameViewModel());
            
            await builder.Build().RunAsync();
        }
    }
}
