using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace dota2_heroes_webApi.Source.Main.Headers;

public class HeadersFromJson
{
    string path;
    public HeadersFromJson(string path)
    {
        this.path = path;
    }
    public async void Get(HttpRequestMessage httpRequestMessage)
    {
        string rawFormat = await File.ReadAllTextAsync(path);
        var dictOfHeaders = JsonConvert.DeserializeObject<Dictionary<string, string>>(rawFormat);
        foreach (var item in dictOfHeaders)
        {
            httpRequestMessage.Headers.Add(item.Key, item.Value);
        }
    }
}