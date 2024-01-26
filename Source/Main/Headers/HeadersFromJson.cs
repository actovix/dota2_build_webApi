using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace dota2_heroes_webApi.Source.Main.Headers;

public class HeadersFromJson
{
    string path;
    public HeadersFromJson(string path = "Headers.json")
    {
        this.path = path;
    }
    public async void Get(HttpRequestHeaders headers)
    {
        string rawFormat = await File.ReadAllTextAsync(path);
        var dictOfHeaders = JsonConvert.DeserializeObject<Dictionary<string, string>>(rawFormat);
        foreach (var item in dictOfHeaders)
        {
            headers.Add(item.Key, item.Value);
        }
    }
}