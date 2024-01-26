using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using dota2_heroes_webApi.Models;

public class BuildParser
{
    string baseUrl = "dotabuff.com";
    string itemSelector = ""; //"match-item-with-time match-item-with-time-bigicon         "
    string imgContainerSelector = ""; //"image-container image-container-item image-container-bigicon"
    string picSelector = ""; //"image-item image-bigicon"
    string purchaseTimeSelector = ""; //"time time-below"
    public BuildParser(string itemSel, string imgContSel, string picSel, string pTimeSel)
    {
        itemSelector = itemSel;
        imgContainerSelector = imgContSel;
        picSelector = picSel;
        purchaseTimeSelector = pTimeSel;
    }
    public List<Item> Parse(IHtmlDocument htmlDocument)
    {
        List<Item> buildItems = new();

        var items = htmlDocument.QuerySelectorAll(itemSelector);

        foreach(var t in items)
        {
            var name = GetAttribute(t, picSelector, "title");
            var pic = GetAttribute(t, picSelector, "src");
            var link = GetAttribute(t, imgContainerSelector + " a", "href");
            var pTime = t.QuerySelector(purchaseTimeSelector)?.InnerHtml;
            var tooltipLink = GetAttribute(t, picSelector, "data-tooltip-url");

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
    string GetAttribute(IElement element, string qSelector, string attribure)
    {
        return element
        ?.QuerySelector(qSelector)
        ?.GetAttribute(attribure)
        ?.Trim();
    }
}