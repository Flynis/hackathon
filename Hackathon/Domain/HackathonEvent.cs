namespace Hackathon.Domain;

public class HackathonEvent
{ 
    public virtual List<Wishlist> HoldEvent(List<Developer> juniors, List<Developer> teamleads)
    {
        var wishlists = new List<Wishlist>();

        foreach(var junior in juniors)
        {
            Developer[] wishlist = junior.FormWishlist(teamleads);
            wishlists.Add(new Wishlist(junior, wishlist));
        }

        foreach (var teamlead in teamleads)
        {
            Developer[] wishlist = teamlead.FormWishlist(juniors);
            wishlists.Add(new Wishlist(teamlead, wishlist));
        }

        return wishlists;
    }
}
