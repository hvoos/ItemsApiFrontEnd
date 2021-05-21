using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ItemsApiConsume.Services;
using ItemsApiConsume.Interfaces;

namespace ItemsApiConsume
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //Define o endereço base das chamadas de api, para que não seja necessário ficar chamando o endereço completo toda vez.
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://itemsapi-h2tecnologia-com.umbler.net") });

            //Aqui a gente faz a injeção da dependencia, em resumo:
            //    Transient objects are always different; a new instance is provided to every controller and every service.
            //    Scoped objects are the same within a request, but different across different requests.
            //    Singleton objects are the same for every object and every request.
            builder.Services.AddScoped<IItemsService, ItemsService>();

            await builder.Build().RunAsync();
        }
    }
}
