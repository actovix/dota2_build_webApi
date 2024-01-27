using dota2_heroes_webApi.Source.AutoCompletion;

namespace dota2_heroes_webApi.Source.AutoCompletion;

public class NameSelector
{
    List<string> names;
    public NameSelector()
    {
        NamesOfHeroes namesOfHeroes = new();
        this.names = namesOfHeroes.GetFromJsonAsync().Result;
    }
    List<string> GetSuggestions(string searchPhrase)
    {
        List<string> result = new();
        foreach (var item in names)
        {
            if(item.StartsWith(searchPhrase))
            {
                result.Add(item);
            }          
        }
        return result;
    }
}