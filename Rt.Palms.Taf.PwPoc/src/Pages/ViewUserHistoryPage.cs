using Microsoft.Playwright;


namespace Rt.Palms.Taf.PwPoc.src.Pages;

internal class ViewUserHistoryPage(IPage page)
{
    private readonly IPage _page = page;
    private ILocator ViewUserHistoryPageHeader => _page.GetByTestId("view-user-history-page-title-header-title");
    public ILocator GetViewUserHistoryPageHeader => ViewUserHistoryPageHeader;
}
