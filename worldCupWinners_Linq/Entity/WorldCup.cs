using System.Text.Json.Serialization;

namespace worldCupWinners_Linq.Entity;

public class WorldCup
{
    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("champion")]
    public string Champion { get; set; }

    [JsonPropertyName("second")]
    public string Second { get; set; }

    [JsonPropertyName("third")]
    public string Third { get; set; }

    [JsonPropertyName("host")]
    public string Host { get; set; }

    [JsonPropertyName("nbTeams")]
    public int NbTeams { get; set; }

    [JsonPropertyName("nbMatches")]
    public int NbMatches { get; set; }

    [JsonPropertyName("nbGoals")]
    public int NbGoals { get; set; }
    
    public WorldCup(int year, string champion, string second, string third, string host, int nbTeams, int nbMatches, int nbGoals)
    {
        Year = year;
        Champion = champion;
        Second = second;
        Third = third;
        Host = host;
        NbTeams = nbTeams;
        NbMatches = nbMatches;
        NbGoals = nbGoals;
    }
}