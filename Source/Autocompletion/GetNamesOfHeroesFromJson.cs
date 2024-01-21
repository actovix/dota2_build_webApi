using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace dota2_heroes_webApi.Source.AutoCompletion;

public class NamesOfHeroes
{
    private string path = "";
    public NamesOfHeroes(string path)
    {
        this.path = path;
    }

    public async Task<List<string>> GetFromJsonAsync()
    {
        string json = await File.ReadAllTextAsync(path);

        List<string> names = JsonConvert.DeserializeObject<List<string>>(json);

        return names;
    }
}