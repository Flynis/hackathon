using System.Diagnostics.CodeAnalysis;

namespace Hackathon.Domain;

public record Wishlist
{
    public required Developer Owner { get; init; }
    public required Developer[] Priorities { get; init; }

    public Wishlist() { }

    [SetsRequiredMembers]
    public Wishlist(Developer owner, Developer[] priorities)
    {
        Owner = owner;
        Priorities = priorities;
    }
}
