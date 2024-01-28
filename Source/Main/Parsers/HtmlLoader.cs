namespace dota2_heroes_webApi.Source.Main.Parsers;

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
    public async Task<string?> GetPageAsync(string heroName, HttpRequestMessage httpRequestMessage)
    {
        if(!Uri.TryCreate(url.Replace(mask, heroName), UriKind.Absolute, out Uri resUri))
            throw new NotImplementedException(); 
        httpRequestMessage.RequestUri = resUri;

        HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
        string responceString = await httpResponseMessage.Content.ReadAsStringAsync();

        await File.AppendAllTextAsync("log.txt", 
            DateTime.Now + " | " + httpResponseMessage.StatusCode + " | " + resUri.ToString());

        return httpResponseMessage.IsSuccessStatusCode ? responceString : null;
    }
}