namespace Hackathon.Model;

public record Team
{
    public Developer Junior { get; private set; }
    public Developer Teamlead { get; private set; }

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
