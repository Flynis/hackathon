using System.Diagnostics.CodeAnalysis;

namespace Hackathon.Domain;

public record Team
{
    public required Developer Junior { get; init; }
    public required Developer Teamlead { get; init; }

    public Team() { }

    [SetsRequiredMembers]
    public Team(Developer junior, Developer teamlead)
    {
        Junior = junior;
        Teamlead = teamlead;
    }
    
    public override string ToString()
    {
        return $"{{{Junior.Id}, {Teamlead.Id}}}";
    }
}
