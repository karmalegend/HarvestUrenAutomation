using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

ServiceProvider BuildServiceProvider()
{
    var services = new ServiceCollection();
    ConfigureServices(services);

    static void ConfigureServices(IServiceCollection serviceCollection)
    {
       
        serviceCollection.AddSingleton<IConfiguration>
            (new ConfigurationBuilder().AddJsonFile("appsettings.json").Build());
    }

    return services.BuildServiceProvider();
}


// using var serviceProvider = BuildServiceProvider();
// var bot = serviceProvider.GetRequiredService<HarvestAutomizerAgent>();
// bot.Start();
