using Hackathon.Application;
using Hackathon.Model;
using NUnit.Framework;

namespace HackathonTest;

public class HrDirectorTest
{
    [Test]
    public void TestCorrectSameNumbersHarmony()
    {
        // Arrange
        var number = 2;
        var numbers = new int[] { number, number };

        // Act
        var harmony = Hackathon.Application.Math.HarmonicMean(numbers);

        // Assert
        Assert.That(harmony, Is.EqualTo(number));
    }
    
    [Test]
    public void TestCorrectDifferentNumbersHarmony()
    {
        // Arrange
        var numbers = new int[] { 2, 6 };
        var expected = 3;

        // Act
        var harmony = Hackathon.Application.Math.HarmonicMean(numbers);

        // Assert
        Assert.That(harmony, Is.EqualTo(expected));
    }
    
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
        
        var team1 = new Team(junior1, teamlead1);
        var team2 = new Team(junior2, teamlead2);
        
        var wishlists = new List<Wishlist> { wishlist1, wishlist2, wishlist3, wishlist4 };
        var teams = new List<Team> { team1, team2 };

        var expected = 1.3333333333333333d;
        var hrDirector = new HrDirector(2, 2);

        // Act 
        var actual = hrDirector.CalculateHarmony(wishlists, teams);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}