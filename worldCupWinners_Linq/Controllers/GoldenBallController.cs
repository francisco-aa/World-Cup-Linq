using DataSources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using worldCupWinners_Linq.Entity;
using Newtonsoft.Json;

namespace worldCupWinners_Linq.Controllers;

[ApiController]
[Route("api/goldenBall")]
public class GoldenBallController : ControllerBase
{
    private List<GoldenBall> goldenBalls = GoldenBallsListData.GoldenBallsList;

    /*
     * get all golden ball winners
     */
    [HttpGet("getAll")]
    public ActionResult<List<GoldenBall>> GetGoldenBalls()
    {
        var goldenBalls =
            from goldenBall in this.goldenBalls
            select goldenBall;
        return Ok(goldenBalls.ToList());
    }

    /*
     * get all golden ball winners
     */
    [HttpGet("getAllSortedBy")]
    public ActionResult<List<GoldenBall>> GetAllSortedBy()
    {
        var goldenBalls =
            from goldenBall in this.goldenBalls
            orderby goldenBall.Year
            select goldenBall;
        return Ok(goldenBalls.ToList());
    }


    /**
     * search golden ball winner
     */
    [HttpGet("search")]
    public ActionResult<List<GoldenBall>> SearchWorldCup([FromQuery] string? year, [FromQuery] string? winner,
        [FromQuery] string? second, [FromQuery] string? third)
    {
        var yearSearch = year.IsNullOrEmpty() ? "" : year;
        var winnerSearch = winner.IsNullOrEmpty() ? "" : winner;
        var secondSearch = second.IsNullOrEmpty() ? "" : second;
        var thirdSearch = third.IsNullOrEmpty() ? "" : third;

        var goldenBalls =
            from goldenBall in this.goldenBalls
            where goldenBall.Year.Contains(yearSearch, StringComparison.InvariantCultureIgnoreCase)
            where goldenBall.Winner.Contains(winnerSearch, StringComparison.InvariantCultureIgnoreCase)
            where goldenBall.Second.Contains(secondSearch, StringComparison.InvariantCultureIgnoreCase)
            where goldenBall.Third.Contains(thirdSearch, StringComparison.InvariantCultureIgnoreCase)
            select goldenBall;

        return Ok(goldenBalls.ToList());
    }
}