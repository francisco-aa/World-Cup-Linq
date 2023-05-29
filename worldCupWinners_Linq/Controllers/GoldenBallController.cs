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
    public ActionResult<List<GoldenBall>> GetAllSortedBy([FromQuery] string? sortedBy)
    {
        var goldenBalls = 
            from goldenBall in this.goldenBalls
            orderby goldenBall.Year
            select goldenBall;
        
        switch (sortedBy)
        {
            case "year":
                goldenBalls =
                    from goldenBall in this.goldenBalls
                    orderby goldenBall.Year
                    select goldenBall;
                break;
            case "winner":
                goldenBalls = from goldenBall in this.goldenBalls
                    orderby goldenBall.Winner
                    select goldenBall;
                break;
            case "second":
                goldenBalls = from goldenBall in this.goldenBalls
                    orderby goldenBall.Second
                    select goldenBall;
                break;
            case "third":
                goldenBalls = from goldenBall in this.goldenBalls
                    orderby goldenBall.Third
                    select goldenBall;
                break;
        }

        return Ok(goldenBalls.ToList());
    }


    /**
     * search golden ball winner
     */
    [HttpGet("search")]
    public ActionResult<List<GoldenBall>> SearchWorldCup(
        [FromQuery] string? year,
        [FromQuery] string? winner,
        [FromQuery] string? second,
        [FromQuery] string? third)
    {

        var goldenBalls =
            from goldenBall in this.goldenBalls
            where year.IsNullOrEmpty() ? true : goldenBall.Year.Contains(year, StringComparison.InvariantCultureIgnoreCase)
            where winner.IsNullOrEmpty() ? true : goldenBall.Winner.Contains(winner, StringComparison.InvariantCultureIgnoreCase)
            where second.IsNullOrEmpty() ? true : goldenBall.Second.Contains(second, StringComparison.InvariantCultureIgnoreCase)
            where third.IsNullOrEmpty() ? true : goldenBall.Third.Contains(third, StringComparison.InvariantCultureIgnoreCase)
            select goldenBall;

        return Ok(goldenBalls.ToList());
    }
}