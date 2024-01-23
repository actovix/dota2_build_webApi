using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using dota2_heroes_webApi.Models;

public class DotaBuffParser
{
    string baseUrl = "dotabuff.com";
    string itemSelector = ""; //"match-item-with-time match-item-with-time-bigicon         "
    string imgContainerSelector = ""; //"image-container image-container-item image-container-bigicon"
    string picSelector = ""; //"image-item image-bigicon"
    string purchaseTimeSelector = ""; //"time time-below"
    public DotaBuffParser(string itemSel, string imgContSel, string picSel, string pTimeSel)
    {
        itemSelector = itemSel;
        imgContainerSelector = imgContSel;
        picSelector = picSel;
        purchaseTimeSelector = pTimeSel;
    }
    public List<Item> Parse(IHtmlDocument htmlDocument)
    {
        List<Item> itemsToPurchase = new();

        var items = htmlDocument.QuerySelectorAll(itemSelector);

        foreach(var t in items)
        {
            var pic = t.QuerySelector(picSelector)?.GetAttribute("src");
            var name = t.QuerySelector(picSelector)?.GetAttribute("oldtitle");
            var link = t.QuerySelector(imgContainerSelector + " a")?.GetAttribute("href");
            var pTime = t.QuerySelector(purchaseTimeSelector)?.InnerHtml;
            var tooltipLink = baseUrl + t.QuerySelector(picSelector)?.GetAttribute("data-tooltip-url");
            itemsToPurchase.Add(new Item()
            {
                PictureLink = pic,
                Link = link,
                Name = name,
                TimeTiPurchase = pTime,
                TooltipLink = tooltipLink
            });
        }
        return itemsToPurchase;
    }
    string GetAttribute(IElement element, string qSelector, string attribure)
    {
        return element
        ?.QuerySelector(qSelector)
        ?.GetAttribute(attribure)
        ?.Trim();
    }
}