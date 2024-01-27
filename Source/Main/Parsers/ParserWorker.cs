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
    }

    public async Task<Build> GetBuildAsync(string uri)
    {
        HttpRequestMessage httpRequestMessage = HttpRequestMessageBuilder.Create(HttpMethod.Get);
        string source = await htmlLoader.GetPageAsync(uri, httpRequestMessage);

        await File.AppendAllTextAsync("log.txt", $"{DateTime.Now} recieved |{uri}");

        HtmlParser htmlParser = new();
        var document = await htmlParser.ParseDocumentAsync(source);

        List<Item> items = parser.Parse(document);

        Build build = new(){
            Items = items,
            LinkToPage = uri
        };

        return build;
    }
}