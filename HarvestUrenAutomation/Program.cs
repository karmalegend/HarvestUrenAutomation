using HarvestUrenAutomation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

ServiceProvider BuildServiceProvider()
{
    var services = new ServiceCollection();
    ConfigureServices(services);

    static void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<WebDriver, FirefoxDriver>();
        serviceCollection.AddSingleton<HarvestAutomizerAgent>();
        serviceCollection.AddSingleton<IConfiguration>
            (new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build());
    }

    return services.BuildServiceProvider();
}


using var serviceProvider = BuildServiceProvider();
var bot = serviceProvider.GetRequiredService<HarvestAutomizerAgent>();
bot.LoginToZohoPeople();




Thread.Sleep(1000000000);

