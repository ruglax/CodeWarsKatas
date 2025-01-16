using System;

public class Program
{
    /// <summary>
    /// Return the century of the input year. The input will always be a 4 digit string, so there is no need for validation.
    /// "1999" --> "20th"
    /// "2011" --> "21st"
    /// "2154" --> "22nd"
    /// "2259" --> "23rd"
    /// "1124" --> "12th"
    /// "2000" --> "20th"
    /// </summary>
    [Theory]
    [InlineData("1999", "20th")]
    [InlineData("2011", "21st")]
    [InlineData("2154", "22nd")]
    [InlineData("2259", "23rd")]
    [InlineData("1124", "12th")]
    [InlineData("2000", "20th")]
    public void Test1(string year, string centuryString)
    {
        var century = (int.Parse(year) - 1) / 100 + 1;
        string centuryValue = century switch
        {
            <= 20 and > 3 => $"{century}th",
            _ when century.ToString().EndsWith("1") => $"{century}st",
            _ when century.ToString().EndsWith("2") => $"{century}nd",
            _ when century.ToString().EndsWith("3") => $"{century}rd",
            _ => $"{century}th"
        };

        Assert.Equal(centuryString, centuryValue);
    }
}