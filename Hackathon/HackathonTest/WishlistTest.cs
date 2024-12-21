using NUnit.Framework;
using Hackathon.Model;

namespace HackathonTest;

public class WishlistTests
{
    [Test]
    public void TestCorrectListSize()
    {
        // Arrange
        var teammates = new List<Developer>();
        for (var i = 0; i < 100; i++)
        {
            teammates.Add(new Developer(i, "Teammate", Jobs.Junior));
        }
        var developer = new Developer(1, "Developer", Jobs.Junior);

        // Act 
        var wishlist = developer.FormWishlist(teammates);

        // Assert
        Assert.That(wishlist.Length, Is.EqualTo(teammates.Count));
    }
    
    [Test]
    public void TestDeveloperExists()
    {
        // Arrange
        var teammates = new List<Developer>();
        for (var i = 0; i < 100; i++)
        {
            teammates.Add(new Developer(i, "Teammate", Jobs.Junior));
        }
        var intern = new Developer(teammates.Count, "Intern", Jobs.Junior);
        teammates.Add(intern);
        var developer = new Developer(1, "Developer", Jobs.Junior);

        // Act
        var wishlist = developer.FormWishlist(teammates);

        // Assert
        Assert.True(wishlist.Contains(intern));
    }
}