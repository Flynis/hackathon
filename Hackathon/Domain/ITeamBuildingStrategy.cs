namespace Hackathon.Domain;

public interface ITeamBuildingStrategy
{
    List<Team> BuildTeams(List<Wishlist> wishlists);
}
