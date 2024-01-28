

using System.ComponentModel.DataAnnotations;

namespace dota2_heroes_webApi.Models;

public class SearchString
{
    [MinLength(1, ErrorMessage = "MinLength must be more or equal then 1")]
    [Required(ErrorMessage = "Is required")]
    // []
    public string SearchHero { get; set; } = "";
    public int waitTimeout;
}