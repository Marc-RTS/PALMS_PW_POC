using Microsoft.Playwright;
using Rt.Palms.Taf.PwPoc.src.Pages.Common;
using Rt.Palms.Taf.PwPoc.src.Pages.Poppers;
using Rt.Palms.Taf.PwPoc.src.Pages.SideBars;

namespace Rt.Palms.Taf.PwPoc.src.Pages;

internal class SearchUserProfilePage (IPage page)
{
    private readonly IPage _page = page;
    private readonly ProfileSidebar _profileSidebar = new(page);
    private readonly SearchFilterSidebar _searchFilterSidebar = new(page);
    private readonly AlertPopper _alertPopper = new(page);
    private readonly BasePopper _basePopper = new(page);
    private readonly SearchContainer _searchContainer = new(page);
 
    private ILocator UserProfileSearchPageHeader => _page.GetByTestId("search-user-profile-page-header-title");
    public ILocator GetUserCustomerProfileHeader => UserProfileSearchPageHeader;
    public ILocator GetPredictiveSearchResult => _basePopper.GetSearchListBox;
    public ILocator GetAlertMessageContents => _alertPopper.GetAlertMessage.GetByRole(AriaRole.Paragraph);
    public async Task EnterSearchInput(string item) => await _searchContainer.FillSearchInput(item);
    public async Task<SearchContainer> SearchUserProfile(string item)
    {
        await _searchContainer.FillSearchInput(item);
        return await _searchContainer.ClickSearch();
    }
}
