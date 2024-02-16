using Microsoft.Playwright;
using Rt.Palms.Taf.PwPoc.src.Pages.Poppers;
using Rt.Palms.Taf.PwPoc.src.Pages.SideBars;

namespace Rt.Palms.Taf.PwPoc.src.Pages;

internal class PalmsHomePage(IPage page)
{
    private readonly IPage _page = page;
    private readonly ProfilePopper _profilePopper = new(page);
    private ILocator PageHeader => _page.Locator("h2");
    private ILocator PageTitle => _page.GetByTestId("appbar-title");
    private ILocator BannerPalms => _page.GetByRole(AriaRole.Banner);
    private ILocator TxtboxUserSapId => _page.GetByTestId("home-set-current-user-input-inner");
    private ILocator BtnSetUser => _page.GetByTestId("home-set-current-user-button");
    private ILocator BtnMenuSideBar => _page.GetByTestId("appbar-open-sidebar");
    private ILocator BtnAvatar => _page.GetByTestId("appbar-avatar");
    private ILocator ContentContainer => _page.Locator("#content-container");
    private ILocator LogoPalms => _page.GetByRole(AriaRole.Img, new() { Name = "palms logo" });
    private ILocator SideMenuSearchCustomerProfile => _page.GetByTestId("sidebar-SearchCustomerProfile");

    public ILocator GetPageHeader => PageHeader;
    public ILocator GetPageTitle => PageTitle;
    public ILocator GetBanner => BannerPalms;
    public ILocator GetMessageContent => ContentContainer;
    public ILocator GetSideMenuSearchCustomerProfile => SideMenuSearchCustomerProfile;
    public async Task ClickSetUser() => await BtnSetUser.ClickAsync();
    public async Task ClickSearchCustomerProfile() => await SideMenuSearchCustomerProfile.ClickAsync();
    public async Task<RouteListSidebar> ClickSideBar()
    {
        await BtnMenuSideBar.ClickAsync();
        return new RouteListSidebar(_page);
    }
    public async Task<ProfilePopper> ClickAvatar() {
        await BtnAvatar.ClickAsync();
        return new ProfilePopper(_page);
    }
    
    public async Task InputSapUserId(string password)
    {
        await TxtboxUserSapId.ClickAsync();
        await TxtboxUserSapId.FillAsync(password);
    }
    public async Task SetSapUserId(string sapUserId)
    {
        await InputSapUserId(sapUserId);
        await ClickSetUser();
    }
    public async Task<AdministratorPortalPage> NavigateToAdminPortalPage()
    {
        var profilePopper = await ClickAvatar();
        if(await profilePopper.GetSwitchView.TextContentAsync() == "Administration"){
            return await profilePopper.ClickAdministration();
        }
        
        return new AdministratorPortalPage(_page);
    }

    public async Task<PalmsHomePage> NavigateToCustomerPortalPage()
    {
        var profilePopper = await ClickAvatar();
        if (await profilePopper.GetSwitchView.TextContentAsync() == "Customer")
        {
            return await profilePopper.ClickCustomer();
        }
        return new PalmsHomePage(_page);
    }

    // Navigate to Sidebar pages
    public async Task<SearchUserProfilePage> NavigateToSearchUserProfilePage()
    {
        await NavigateToAdminPortalPage();
        var sideBar = await ClickSideBar();
        return await sideBar.NavigateToSearchUserProfilePage();
    }

    public async Task<ManageRolePermissionPage> NavigateToManageRolePermissionsPage()
    {
        await NavigateToAdminPortalPage();
        var sideBar = await ClickSideBar();
        return await sideBar.NavigateToManageRolePermissionsPage();
    }
    public async Task<ManageUserRolesPage> NavigateToManageUserRolesPage()
    {
        await NavigateToAdminPortalPage();
        var sideBar = await ClickSideBar();
        return await sideBar.NavigateToManageUserRolesPage();
    }

}
