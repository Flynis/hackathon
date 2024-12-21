using Hackathon.Application;
using Hackathon.Model;
using NUnit.Framework;

namespace HackathonTest;

public class HackathonTest
{
    [Test]
    public void TestCorrectHarmonyResult()
    {
        // Arrange
        var junior1 = new Developer(1, "Junior", Jobs.Junior);
        var teamlead1 = new Developer(2, "Teamlead", Jobs.Teamlead);

        var junior2 = new Developer(3, "Junior", Jobs.Junior);
        var teamlead2 = new Developer(4, "Teamlead", Jobs.Teamlead);

        var wishlist1 = new Wishlist(junior1, [teamlead1, teamlead2]);
        var wishlist2 = new Wishlist(junior2, [teamlead1, teamlead2]);

        var wishlist3 = new Wishlist(teamlead1, [junior1, junior2]);
        var wishlist4 = new Wishlist(teamlead2, [junior1, junior2]);
        var wishlists = new List<Wishlist> { wishlist1, wishlist2, wishlist3, wishlist4 };
        var expected = 1.3333333333333333d;

        // Act
        var teams = new HrManager(new OnlyJuniorWishTeamBuildingStrategy()).BuildTeams(wishlists);
        var harmony = new HrDirector(2, 2).CalculateHarmony(wishlists, teams);

        // Assert
        Assert.That(harmony, Is.EqualTo(expected));
    }
}