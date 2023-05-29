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
        var worldCups =
            from worldCup in worldCupList()
            select worldCup;

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
    public ActionResult<List<WorldCup>> SearchWorldCup(
        [FromQuery] string? year,
        [FromQuery] string? champion,
        [FromQuery] string? second,
        [FromQuery] string? third,
        [FromQuery] string? host,
        [FromQuery] int? nbTeams,
        [FromQuery] int? nbMatches,
        [FromQuery] int? nbGoals)
    {
        var worldCups =
            from worldcup in worldCupList()
            where year.IsNullOrEmpty()
                ? true
                : worldcup.Year.Contains(year, StringComparison.InvariantCultureIgnoreCase)
            where champion.IsNullOrEmpty()
                ? true
                : worldcup.Champion.Contains(champion, StringComparison.InvariantCultureIgnoreCase)
            where second.IsNullOrEmpty()
                ? true
                : worldcup.Second.Contains(second, StringComparison.InvariantCultureIgnoreCase)
            where third.IsNullOrEmpty()
                ? true
                : worldcup.Year.Contains(third, StringComparison.InvariantCultureIgnoreCase)
            where host.IsNullOrEmpty()
                ? true
                : worldcup.Host.Contains(host, StringComparison.InvariantCultureIgnoreCase)
            where nbTeams.HasValue ? worldcup.NbTeams == nbTeams : true
            where nbMatches.HasValue ? worldcup.NbMatches == nbMatches : true
            where nbGoals.HasValue ? worldcup.NbGoals == nbGoals : true
            select worldcup;

        return Ok(worldCups.ToList());
    }
}