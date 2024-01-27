namespace dota2_heroes_webApi.Source.Main.Settings;

public interface IParserSettings
{
    string Url { get; set; }
    int StartPoint { get; set; }
    int EndPoint { get; set; }
}