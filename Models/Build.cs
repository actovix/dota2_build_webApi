namespace dota2_heroes_webApi.Models;

public class Build
{
    public string HeroName { get; set; } = "";
    public string LinkToPage { get; set; } = "";
    public List<Item> Items { get; set; }
}