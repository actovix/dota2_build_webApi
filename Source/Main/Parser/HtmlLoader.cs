using System.Net.Http;

namespace dota2_heroes_webApi.Main.Parser;

public class HtmlLoader
{
    private string mask;
    private readonly HttpClient httpClient;
    private readonly string url; // https://www.dotabuff.com/heroes/{heroName}
    public HtmlLoader(HttpClient httpClient, string url, string mask)
    {
        this.httpClient = httpClient;
        this.url = url;
        this.mask = mask;
    }
    public async Task<string> GetPageAsync(string heroName)
    {
        string resUrl = url.Replace(mask, heroName);
        HttpResponseMessage resp = await httpClient.GetAsync(resUrl);

        await File.AppendAllTextAsync("log.txt", DateTime.Now + " | " + resUrl + " : " + resp.StatusCode);

        return resp.IsSuccessStatusCode ? await resp.Content.ReadAsStringAsync() : "";
    }
}