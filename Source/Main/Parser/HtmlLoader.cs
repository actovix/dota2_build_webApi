using System.Net;

namespace dota2_heroes_webApi.Main.Parser;

public class HtmlLoader
{
    private readonly HttpClient httpClient;
    private readonly string url;
    public HtmlLoader(HttpClient httpClient, string url)
    {
        this.httpClient = httpClient;
        this.url = url;
    }
    public Task<string> GetPageAsync(string HeroNameRegex)
    {
        throw new NotImplementedException();
    }
}