namespace Hackathon.Application;

public class Math
{
    public static double HarmonicMean(int[] numbers)
    {
        var sum = 0.0;

        foreach (var number in numbers)
        {
            sum += 1.0 / number;
        }

        return numbers.Length / sum;
    }
}
