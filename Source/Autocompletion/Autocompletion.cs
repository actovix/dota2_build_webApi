

namespace dota2_heroes_webApi.Source.AutoCompletion;

public class NameSelector
{
    List<string> names;
    public NameSelector(List<string> names)
    {
        this.names = names;
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