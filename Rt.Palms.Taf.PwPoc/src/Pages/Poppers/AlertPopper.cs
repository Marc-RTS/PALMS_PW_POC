using Microsoft.Playwright;

namespace Rt.Palms.Taf.PwPoc.src.Pages.Poppers;

internal class AlertPopper(IPage page)
{
    private readonly IPage _page = page;
    private ILocator AlertMessage => _page.Locator(".MuiAlert-message");
    public ILocator GetAlertMessage => AlertMessage;
}
