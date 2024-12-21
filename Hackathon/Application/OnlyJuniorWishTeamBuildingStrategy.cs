using Hackathon.Model;

namespace Hackathon.Application;

public class OnlyJuniorWishTeamBuildingStrategy : ITeamBuildingStrategy
{
    public List<Team> BuildTeams(List<Wishlist> wishlists)
    {
        var chosenTeamleads = new HashSet<Developer>();
        var teams = new List<Team>();

        foreach (Wishlist wishlist in wishlists)
        {
            var owner = wishlist.Owner;
            if (owner.Job != Jobs.Junior)
            {
                continue;
            }

            var teamleadIndex = 0;
            var priorities = wishlist.Priorities;
            while (chosenTeamleads.Contains(priorities[teamleadIndex]))
            {
                teamleadIndex++;
            }

            var teamlead = priorities[teamleadIndex];
            chosenTeamleads.Add(teamlead);

            teams.Add(new Team(owner, teamlead));
        }

        return teams;
    }
}
