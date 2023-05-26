namespace worldCupWinners_Linq.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("WorldCupWinner")]
public class WorldCupWinner
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Year { get; set; }

    public string Champion { get; set; }

    public string Second { get; set; }

    public string Third { get; set; }

    public string Host { get; set; }

    public string Teams { get; set; }

    public string Matches { get; set; }

    public string Goals { get; set; }
}