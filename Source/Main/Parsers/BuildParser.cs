using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using dota2_heroes_webApi.Models;

namespace dota2_heroes_webApi.Source.Main.Parsers;

public class BuildItemsParser : IParser
{
    string baseUrl = "dotabuff.com";
    string itemSelector;           //"match-item-with-time match-item-with-time-bigicon         "
    string imgContainerSelector;   //"image-container image-container-item image-container-bigicon"
    string picSelector;            //"image-item image-bigicon"
    string purchaseTimeSelector;   //"time time-below"
    public BuildItemsParser(
        string itemSel = ".match-item-with-time.match-item-with-time-bigicon",
        string imgContSel = ".image-container.image-container-item.image-container-bigicon",
        string picSel = ".image-item.image-bigicon",
        string pTimeSel = ".time.time-below"
        )
    {
        itemSelector = itemSel;
        imgContainerSelector = imgContSel;
        picSelector = picSel;
        purchaseTimeSelector = pTimeSel;
    }
    public List<Item> Parse(IHtmlDocument htmlDocument)
    {
        List<Item> buildItems = [];

        var items = htmlDocument.QuerySelectorAll(itemSelector);

        foreach(var t in items)
        {
            var name = GetAttribute(t, picSelector, "title");
            var pic = baseUrl + GetAttribute(t, picSelector, "src");
            var link = baseUrl + GetAttribute(t, imgContainerSelector + " a", "href");
            var tooltipLink = baseUrl + GetAttribute(t, picSelector, "data-tooltip-url");
            var pTime = t.QuerySelector(purchaseTimeSelector)?.InnerHtml;

            buildItems.Add(new Item()
            {
                PictureLink = pic,
                Link = link,
                Name = name,
                TimeTiPurchase = pTime,
                TooltipLink = tooltipLink
            });
        }
        return buildItems;
    }
    string? GetAttribute(IElement element, string qSelector, string attribure)
    {
        return element
        ?.QuerySelector(qSelector)
        ?.GetAttribute(attribure)
        ?.Trim();
    }

    
}