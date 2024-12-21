namespace Hackathon.Model;

public interface ITeamBuildingStrategy
{
    List<Team> BuildTeams(List<Wishlist> wishlists);
}
