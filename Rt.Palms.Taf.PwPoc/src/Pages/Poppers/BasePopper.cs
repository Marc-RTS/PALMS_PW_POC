using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace Rt.Palms.Taf.PwPoc.src.Pages.Poppers;

internal class BasePopper(IPage page)
{
    private readonly IPage _page = page;

    private ILocator SearchListBox => _page.GetByRole(AriaRole.Listbox);
    public ILocator GetSearchListBox => SearchListBox;
}
