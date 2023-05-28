using System.Text.Json.Serialization;

namespace worldCupWinners_Linq.Entity;

public class WorldCup
{
    [JsonPropertyName("year")]
    public string Year { get; set; }

    [JsonPropertyName("champion")]
    public string Champion { get; set; }

    [JsonPropertyName("second")]
    public string Second { get; set; }

    [JsonPropertyName("third")]
    public string Third { get; set; }

    [JsonPropertyName("host")]
    public string Host { get; set; }

    [JsonPropertyName("nbTeams")]
    public string NbTeams { get; set; }

    [JsonPropertyName("nbMatches")]
    public string NbMatches { get; set; }

    [JsonPropertyName("nbGoals")]
    public string NbGoals { get; set; }
    
    public WorldCup(string year, string champion, string second, string third, string host, string nbTeams, string nbMatches, string nbGoals)
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