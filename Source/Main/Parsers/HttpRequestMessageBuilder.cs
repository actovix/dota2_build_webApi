using dota2_heroes_webApi.Source.Main.Headers;

namespace dota2_heroes_webApi.Source.Main.Parsers;

public static class HttpRequestMessageBuilder
{
    static HeadersFromJson headersFromJson;
    public static HttpRequestMessage Create(HttpMethod method, 
        string path = "/home/matthew/source_cs/dota2_heroes_webApi/Source/Main/Headers/Headers.json")
    {
        headersFromJson ??= new HeadersFromJson(path);
        HttpRequestMessage httpRequestMessage = new();
        httpRequestMessage.Method = method;
        headersFromJson.Get(httpRequestMessage);
        return httpRequestMessage;
    }
}