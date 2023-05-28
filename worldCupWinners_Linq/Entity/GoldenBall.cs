using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace worldCupWinners_Linq.Entity;

public class GoldenBall
{
    [JsonProperty("year")]
    public string Year { get; set; }

    [JsonProperty("winner")]
    public string Winner { get; set; }

    [JsonProperty("second")]
    public string Second { get; set; }

    [JsonProperty("third")]
    public string Third { get; set; }

    public GoldenBall(string year, string goldenBallWinner, string silverBall, string bronzeBall)
    {
        Year = year;
        Winner = goldenBallWinner;
        Second = silverBall;
        Third = bronzeBall;
    }
}