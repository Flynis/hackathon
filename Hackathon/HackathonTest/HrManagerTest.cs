using NUnit.Framework;
using Hackathon.Model;
using Moq;
using Hackathon.Application;

namespace HackathonTest;

public class HrManagerTest
{
    [Test]
    public void TestCorrectTeamlistSize()
    {
        // Arrange
        var juniors = new List<Developer>();
        var teamleads = new List<Developer>();
        for (int i = 0; i < 10; i++)
        {
            juniors.Add(new Developer(i, "Junior", Jobs.Junior));
            teamleads.Add(new Developer(i, "Teamlead", Jobs.Teamlead));
        }

        // Act
        var hackathon = new HackathonEvent();
        var wishlists = hackathon.HoldEvent(juniors, teamleads);
        var result = new HrManager(new OnlyJuniorWishTeamBuildingStrategy()).BuildTeams(wishlists);

        // Assert
        Assert.That(result.Count * 2, Is.EqualTo(wishlists.Count));
    }
    
    [Test]
    public void TestCorrectStrategyResult()
    {
        // Arrange
        var junior = new Developer(1, "Junior", Jobs.Junior);
        var teamlead = new Developer(2, "Teamlead", Jobs.Teamlead);
        var juniorWishList = new Wishlist(junior, [teamlead]);
        var teamleadWishlist = new Wishlist(teamlead, [junior]);
        var wishlists = new List<Wishlist>() { juniorWishList, teamleadWishlist };

        // Act
        var result = new HrManager(new OnlyJuniorWishTeamBuildingStrategy()).BuildTeams(wishlists);

        // Assert
        Assert.That(result[0], Is.EqualTo(new Team(junior, teamlead)));
    }
    
    [Test]
    public void TestStrategyInvokedOnce()
    {
        // Arrange
        var junior = new Developer(1, "Junior", Jobs.Junior);
        var teamlead = new Developer(2, "Teamlead", Jobs.Teamlead);
        var juniorWishList = new Wishlist(junior, [teamlead]);
        var teamleadWishlist = new Wishlist(teamlead, [junior]);
        var wishlists = new List<Wishlist>() { juniorWishList, teamleadWishlist };

        var strategyMock = new Mock<ITeamBuildingStrategy>();
        strategyMock.Setup(s => s.BuildTeams(new List<Wishlist>())).Returns([]);

        // Act
        var result = new HrManager(strategyMock.Object).BuildTeams(wishlists);

        // Assert
        strategyMock.Verify(mock => mock.BuildTeams(wishlists), Times.Once());
    }
}