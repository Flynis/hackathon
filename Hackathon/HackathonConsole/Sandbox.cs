using Microsoft.Extensions.Hosting;
using Hackathon.Domain;

namespace Hackathon.HackathonConsole;

public class Sandbox  : IHostedService
{
    private HrManager _hrManager;
    private HrDirector _hrDirector;
    private HackathonEvent _hackathon;
    private List<Developer> _juniors;
    private List<Developer> _teamleads;

    public Sandbox(HrManager hrManager, HrDirector hrDirector, HackathonEvent hackathon)
    {
        _juniors = CsvReader.ReadDevs("resourses/Juniors20.csv", Jobs.Junior);
        _teamleads = CsvReader.ReadDevs("resourses/Teamleads20.csv", Jobs.Teamlead);
        _hrManager = hrManager;
        _hrDirector = hrDirector;
        _hackathon = hackathon;
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        var sumHarmony = 0.0;
        var hackathonsCount = 10;

        for (int i = 0; i < hackathonsCount; i++)
        {
            List<Wishlist> wishlists = _hackathon.HoldEvent(_juniors, _teamleads);
            List<Team> teams = _hrManager.BuildTeams(wishlists);
            double harmony = _hrDirector.CalculateHarmony(wishlists, teams);
            sumHarmony += harmony;
            Console.WriteLine($"Experiment {i + 1}: {harmony}");
        }

        double averageHarmony = sumHarmony / hackathonsCount;
        Console.WriteLine("harmony " + averageHarmony);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}