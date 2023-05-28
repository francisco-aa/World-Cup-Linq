using DataSources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using worldCupWinners_Linq.Entity;
using Newtonsoft.Json;

namespace worldCupWinners_Linq.Controllers;

[ApiController]
[Route("api/worldCup")]
public class WorldCupController : ControllerBase
{
    /*
     * Json to Collection
     */
    public static List<WorldCup> worldCupList()
    {
        string jsonContent = System.IO.File.ReadAllText("./DataSources/worldCup.json");
        return JsonConvert.DeserializeObject<List<WorldCup>>(jsonContent).ToList();
    }

    /**
     * get all world cups
     */
    [HttpGet("getAll")]
    public ActionResult<List<WorldCup>> GetAll()
    {
        var worldCups =
            from worldCup in worldCupList()
            select worldCup;
        return Ok(worldCups.ToList());
    }

    /**
     * get all world cups sorted
     */
    [HttpGet("getAllSortedBy")]
    public ActionResult<List<WorldCup>> GetAllSortedBy([FromQuery] string? sortedBy)
    {
        IOrderedEnumerable<WorldCup> worldCups = null;
        switch (sortedBy)
        {
            case "year":
                worldCups =
                    from worldCup in worldCupList()
                    orderby worldCup.Year
                    select worldCup;
                break;
            case "champion":
                worldCups = from worldCup in worldCupList()
                    orderby worldCup.Champion
                    select worldCup;
                break;
            case "second":
                worldCups = from worldCup in worldCupList()
                    orderby worldCup.Second
                    select worldCup;
                break;
            case "third":
                worldCups = from worldCup in worldCupList()
                    orderby worldCup.Third
                    select worldCup;
                break;
            case "host":
                worldCups = from worldCup in worldCupList()
                    orderby worldCup.Host
                    select worldCup;
                break;
            case "nbTeams":
                worldCups = from worldCup in worldCupList()
                    orderby worldCup.NbTeams
                    select worldCup;
                break;
            case "nbMatches":
                worldCups = from worldCup in worldCupList()
                    orderby worldCup.NbMatches
                    select worldCup;
                break;
            case "nbGoals":
                worldCups = from worldCup in worldCupList()
                    orderby worldCup.NbGoals 
                    select worldCup;
                break;
        }

        return Ok(worldCups.ToList());
    }

    /**
     * search world cup
     */
    [HttpGet("search")]
    public ActionResult<List<WorldCup>> SearchWorldCup([FromQuery] string? year, [FromQuery] string? champion,
        [FromQuery] string? second, [FromQuery] string? third, [FromQuery] string? host, [FromQuery] string? nbTeams,
        [FromQuery] string? nbMatches, [FromQuery] string? nbGoals)
    {
        var yearSearch = year.IsNullOrEmpty() ? "" : year;
        var championSearch = champion.IsNullOrEmpty() ? "" : champion;
        var secondSearch = second.IsNullOrEmpty() ? "" : second;
        var thirdSearch = third.IsNullOrEmpty() ? "" : third;
        var hostSearch = host.IsNullOrEmpty() ? "" : host;
        var nbTeamsSearch = nbTeams.IsNullOrEmpty() ? "" : nbTeams;
        var nbMatchesSearch = nbMatches.IsNullOrEmpty() ? "" : nbMatches;
        var nbGoalsSearch = nbGoals.IsNullOrEmpty() ? "" : nbGoals;

        var worldCups =
            from worldcup in worldCupList()
            where worldcup.Year.Contains(yearSearch, StringComparison.InvariantCultureIgnoreCase)
            where worldcup.Champion.Contains(championSearch, StringComparison.InvariantCultureIgnoreCase)
            where worldcup.Second.Contains(secondSearch, StringComparison.InvariantCultureIgnoreCase)
            where worldcup.Third.Contains(thirdSearch, StringComparison.InvariantCultureIgnoreCase)
            where worldcup.Host.Contains(hostSearch, StringComparison.InvariantCultureIgnoreCase)
            where worldcup.NbTeams.Contains(nbTeamsSearch, StringComparison.InvariantCultureIgnoreCase)
            where worldcup.NbMatches.Contains(nbMatchesSearch, StringComparison.InvariantCultureIgnoreCase)
            where worldcup.NbGoals.Contains(nbGoalsSearch, StringComparison.InvariantCultureIgnoreCase)
            select worldcup;

        return Ok(worldCups.ToList());
    }
}