using Microsoft.Playwright;


namespace Rt.Palms.Taf.PwPoc.src.Pages.SideBars;

internal class RouteListSidebar(IPage page)
{
    private readonly IPage _page = page;
    private ILocator SideMenuSearchUserProfile => _page.GetByTestId("sidebar-SearchUserProfile");
    private ILocator SideMenuManageUserRoles => _page.GetByTestId("sidebar-ManageUserRoles");
    private ILocator SideMenuManageRoles => _page.GetByTestId("sidebar-ManageRoles");
    
    private ILocator SideMenuManageRolePermissions => _page.GetByTestId("sidebar-ManageRolePermissions");
    private ILocator SideMenuManageReferenceDataa => _page.GetByTestId("sidebar-ManageReferenceData");
    private ILocator SideMenuViewUserHistory => _page.GetByTestId("sidebar-ViewUserHistory");
    private ILocator SideMenuSearchCustomerProfile => _page.GetByTestId("sidebar-SearchCustomerProfile");
    private ILocator SideMenuTapLanding => _page.GetByTestId("sidebar-TapLanding");
    private ILocator SideMenuTapRequestQueue => _page.GetByTestId("sidebar-TapRequestQueue");

    public ILocator GetSideMenuManageRoles => SideMenuManageRoles;
    public async Task<SearchUserProfilePage> NavigateToSearchUserProfilePage()
    {
        await SideMenuSearchUserProfile.ClickAsync();
        return new SearchUserProfilePage(_page);
    }
    public async Task<ManageUserRolesPage> NavigateToManageUserRolesPage()
    {
        await SideMenuManageUserRoles.ClickAsync();
        return new ManageUserRolesPage(_page);
    }

    public async Task<ManageRolePermissionPage> NavigateToManageRolePermissionsPage()
    {
        await SideMenuManageRolePermissions.ClickAsync();
        return new ManageRolePermissionPage(_page);
    }

    public async Task<ManageRolesPage> NavigateToManageRolesPage()
    {
        await SideMenuManageRoles.ClickAsync();
        return new ManageRolesPage(_page);
    }

}
