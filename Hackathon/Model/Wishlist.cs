namespace Hackathon.Model;

public record Wishlist
{
    public Developer Owner { get; private set; }
    public Developer[] Priorities { get; private set; }

    public Wishlist(Developer owner, Developer[] priorities)
    {
        Owner = owner;
        Priorities = priorities;
    }
}
