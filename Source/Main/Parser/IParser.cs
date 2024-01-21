using AngleSharp.Html.Dom;
using dota2_heroes_webApi.Models;

namespace dota2_heroes_webApi.Main.Parser.Settings;

public interface IParser
{
    Item Parser(IHtmlDocument htmlDocument);
}
