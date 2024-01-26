using AngleSharp.Html.Dom;
using dota2_heroes_webApi.Models;

namespace dota2_heroes_webApi.Source.Main.Parsers;

public interface IParser
{
    List<Item> Parse(IHtmlDocument htmlDocument);
}
