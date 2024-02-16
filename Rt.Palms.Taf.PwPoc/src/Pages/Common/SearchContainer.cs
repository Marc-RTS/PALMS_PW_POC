using Microsoft.Playwright;
using Rt.Palms.Taf.PwPoc.src.Pages.Poppers;
using Rt.Palms.Taf.PwPoc.src.Pages.SideBars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rt.Palms.Taf.PwPoc.src.Pages.Common;

internal class SearchContainer(IPage page)
{
    private readonly IPage _page = page;
    private ILocator TxtboxSearch => _page.GetByTestId("fuzzy-search-input-base").GetByRole(AriaRole.Combobox);
    private ILocator BtnSearch => _page.GetByTestId("search-fuzzy-search-text-button");
    private ILocator ListSearchResult => _page.GetByRole(AriaRole.Listitem);
    private ILocator BtnCreateCustomerProfile => _page.GetByTestId("search-create-customer-profile-button");
    private ILocator ChkboxPalmsOnly => _page.Locator("Mui-checked");

    public ILocator GetListSearchResult => ListSearchResult;
    public ILocator GetBtnCreateCustomerProfile => BtnCreateCustomerProfile;
    public ILocator GetChkboxPalmsOnly => ChkboxPalmsOnly;

    public async Task<SearchContainer> ClickSearch()
    {
        await BtnSearch.ClickAsync();
        return new SearchContainer(_page);
    }
    public async Task FillSearchInput(string item)
    {
        await TxtboxSearch.FillAsync(item);
    }
    public async Task ClickSearchResultActionButton(string sapUserId)
    {
        await _page.GetByTestId($"search-results-{sapUserId}-action-button").ClickAsync();

    }
    public async Task<ManageUserRolesPage> NavigateToManageUserRolePage(string sapUserId)
    {
        await ClickSearchResultActionButton(sapUserId);
        await _page.GetByTestId($"search-results-{sapUserId}-manage-user-roles-menu-item").ClickAsync();
        return new ManageUserRolesPage(_page);
    }

    public async Task<ViewUserHistoryPage> NavigateToViewUserHistoryPage(string sapUserId)
    {
        await ClickSearchResultActionButton(sapUserId);
        await _page.GetByTestId($"search-results-{sapUserId}-view-user-history-menu-item").ClickAsync();
        return new ViewUserHistoryPage(_page);
    }
    public async Task<ProfileSidebar> ClickSearchResultItemButton(string sapUserId)
    {
        await _page.GetByTestId($"search-results-{sapUserId}-result-item-button").ClickAsync();
        return new ProfileSidebar(_page);
    }
}
