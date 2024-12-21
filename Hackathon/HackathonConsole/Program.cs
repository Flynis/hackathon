using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Hackathon.Model;
using Hackathon.Application;

namespace Hackathon.HackathonConsole;

class Application  {
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        var developersCount = 20;
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Sandbox>();
                services.AddTransient<ITeamBuildingStrategy, OnlyJuniorWishTeamBuildingStrategy>();
                services.AddTransient<HackathonEvent>();
                services.AddTransient<HrManager>();
                services.AddTransient<HrDirector>(_ => new HrDirector(developersCount, developersCount));
            });
    }
}