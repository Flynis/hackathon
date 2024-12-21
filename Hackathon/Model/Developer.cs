namespace Hackathon.Model;

public class Developer
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public Jobs Job { get; private set; }

    public Developer(int id, string name, Jobs job) 
    {
        Id = id;
        Name = name;
        Job = job;
    }

    public Developer[] FormWishlist(List<Developer> teammates)
    {
        Developer[] wishlist = teammates.ToArray();
        var rand = new Random();

        for (int i = 0; i < wishlist.Length - 1; i++)
        {
            int j = rand.Next(0, teammates.Count);

            (wishlist[j], wishlist[i]) = (wishlist[i], wishlist[j]);
        }

        return wishlist;
    }

    public override string ToString()
    {
        return $"{{{Id}, {Name}}}";
    }
}
