using dota2_heroes_webApi.Models;
using dota2_heroes_webApi.Source.Main.Settings;
using AngleSharp.Html.Parser;

namespace dota2_heroes_webApi.Source.Main.Parsers;

public class ParserWorker
{
    private IParser parser;
    private IParserSettings parserSettings;
    private HtmlLoader htmlLoader;

    public IParser Parser { get => parser; set => parser = value; }

    public ParserWorker(IParser parser)
    {
        this.parser = parser;
        this.htmlLoader = new(
            new HttpClient(), 
            "https://www.dotabuff.com/heroes/{heroName}", 
            "{heroName}");
    }

    public async Task<Build> GetBuildAsync(string heroName)
    {
        HttpRequestMessage httpRequestMessage = HttpRequestMessageBuilder.Create(HttpMethod.Get);
        string? source = await htmlLoader.GetPageAsync(heroName, httpRequestMessage);

        await File.AppendAllTextAsync("log.txt", $"{DateTime.Now} recieved |{heroName}");

        HtmlParser htmlParser = new();
        var document = await htmlParser.ParseDocumentAsync(source);

        List<Item> items = parser.Parse(document);

        Build build = new(){
            Items = items,
            LinkToPage = httpRequestMessage.RequestUri.ToString()
        };

        return build;
    }
}