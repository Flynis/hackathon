using Microsoft.Extensions.Hosting;
using Hackathon.Model;
using Hackathon.Application;

namespace Hackathon.HackathonConsole;

public class Sandbox  : IHostedService
{
    private HrManager _hrManager;
    private HrDirector _hrDirector;
    private HackathonEvent _hackathon;
    private List<Developer> _juniors = [];
    private List<Developer> _teamleads = [];
    private bool _isDeveloperListsLoaded = false;

    public Sandbox(HrManager hrManager, HrDirector hrDirector, HackathonEvent hackathon)
    {
        _hrManager = hrManager;
        _hrDirector = hrDirector;
        _hackathon = hackathon;
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        var sumHarmony = 0.0;
        var hackathonsCount = 1000;
        if (!_isDeveloperListsLoaded)
        {
            _juniors = CsvReader.ReadDevs("resourses/Juniors20.csv", Jobs.Junior);
            _teamleads = CsvReader.ReadDevs("resourses/Teamleads20.csv", Jobs.Teamlead);
            _isDeveloperListsLoaded = true;
        }

        for (int i = 0; i < hackathonsCount; i++)
        {
            var wishlists = _hackathon.HoldEvent(_juniors, _teamleads);
            var teams = _hrManager.BuildTeams(wishlists);
            var harmony = _hrDirector.CalculateHarmony(wishlists, teams);
            sumHarmony += harmony;
            Console.WriteLine($"Experiment {i + 1}: {harmony}");
        }

        var averageHarmony = sumHarmony / hackathonsCount;
        Console.WriteLine("harmony " + averageHarmony);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}