
using NUnit.Allure.Core;
using Rt.Palms.Taf.PwPoc.src.Fixtures.Implementation;
using Rt.Palms.Taf.PwPoc.src.Pages;
using Rt.Palms.Taf.PwPoc.src.Support;
using Rt.Palms.Taf.PwPoc.src.Pages.Poppers;


namespace Rt.Palms.Taf.PwPoc.src.Tests.UI.Administration;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
[AllureNUnit]
public class AdminPortalTest : BaseTest
{
    private static Mock _mock;
    private static LoginPage _loginPage;
    private static PalmsHomePage _palmsHomePage;
    private static SaveOrClearChangesPopper _saveOrCancelChangesPopper;

    [SetUp]
    public async Task Setup()
    {
        _mock = new Mock(Page);
        _loginPage = new LoginPage(Page);
        _palmsHomePage = new PalmsHomePage(Page);
        _saveOrCancelChangesPopper = new SaveOrClearChangesPopper(Page);
        await _loginPage.OpenUrl();
    }

    [Test]
    public async Task AccessAdminPortalAsRegionalAdministratorInMultipleRegions()
    {
        var user = User.GetBothAusAndCanRegionUser();
        await _mock.GetBothAusAndCanAdminUserResponses();

        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        var adminPortalPage = await _palmsHomePage.NavigateToAdminPortalPage();
        await Expect(adminPortalPage.GetAdministratorPortalPageHeader).ToHaveTextAsync(Constants.AdministratorPortalHeader);
        await Expect(adminPortalPage.GetAdministratorPortalPageTitle).ToHaveTextAsync(Constants.PalmsAdminPortalTitle);
        await Expect(adminPortalPage.GetRegionSelector).ToBeVisibleAsync();

        await adminPortalPage.ClickRegionSelector();
        await Expect(adminPortalPage.GetRegionAusIronOre).ToHaveTextAsync("Australia - Iron Ore");
        await Expect(adminPortalPage.GetRegionCanIronOre).ToHaveTextAsync("Canada - Iron Ore");

        await adminPortalPage.SelectAusIronOreRegion();
        await Expect(adminPortalPage.GetAdministratorPortalPageTitle).ToHaveTextAsync(Constants.AusIronOreAdminPortalTitle);

        await adminPortalPage.SwitchToCanIronOreRegion();
        await Expect(adminPortalPage.GetAdministratorPortalPageTitle).ToHaveTextAsync(Constants.CanIronOreAdminPortalTitle);
    }

    [Test]
    public async Task GlobalAdministratorIsAbleToUpdateRolePermissionForGlobalRoles()
    {
        var user = User.GetGlobalUser();
        await _mock.GetGlobalAdminUserResponses();
        await _mock.GetPermissionRoleFilter(PermissionRoleFilter.GetGlobalPermissionRoleFilterFixture);

        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        var adminPortalPage = await _palmsHomePage.NavigateToAdminPortalPage();
        await Expect(adminPortalPage.GetAdministratorPortalPageHeader).ToHaveTextAsync(Constants.AdministratorPortalHeader);
        await Expect(adminPortalPage.GetAdministratorPortalPageTitle).ToHaveTextAsync(Constants.PalmsAdminPortalTitle);
        await Expect(adminPortalPage.GetRegionSelector).ToBeVisibleAsync();

        await adminPortalPage.ClickRegionSelector();
        await Expect(adminPortalPage.GetRegionAusIronOre).ToHaveTextAsync("Australia - Iron Ore");
        await Expect(adminPortalPage.GetRegionCanIronOre).ToHaveTextAsync("Canada - Iron Ore");
        await Expect(adminPortalPage.GetRegionGlobal).ToHaveTextAsync("Global");

        await adminPortalPage.SelectGlobalRegion();
        await Expect(adminPortalPage.GetAdministratorPortalPageTitle).ToHaveTextAsync(Constants.GlobalAdminPortalTitle);

        var manageRolePermissionsPage = await _palmsHomePage.NavigateToManageRolePermissionsPage();
        await Expect(manageRolePermissionsPage.GetManageRolePermissionPageHeader).ToHaveTextAsync("Manage role permissions");

        await manageRolePermissionsPage.FilterPalmsRole("All");
        await manageRolePermissionsPage.SelectRowPermission("Audit", "Global administrator", "No Access");
        await manageRolePermissionsPage.SelectRowPermission("Audit", "Regional administrator", "No Access");
        await manageRolePermissionsPage.SelectRowPermission("Audit", "Suspended", "Enabled");
        await Expect(manageRolePermissionsPage.GetBtnSaveChanges).ToBeEnabledAsync();
        await Expect(manageRolePermissionsPage.GetBtnCancelChanges).ToBeEnabledAsync();
    }

    [Test]
    public async Task RegionalAdministratorCanOnlyViewRolePermissionsOfRegionalAdministratorButCanEditOtherRoles()
    {
        var user = User.GetAusRegionUser();
        await _mock.GetAusRegionalAdminUserResponses();
        await _mock.GetPermissionRoleFilter(PermissionRoleFilter.GetRegionalPermissionRoleFilterFixture("Regional administrator"));

        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        var adminPortalPage = await _palmsHomePage.NavigateToAdminPortalPage();
        await Expect(adminPortalPage.GetAdministratorPortalPageHeader).ToHaveTextAsync(Constants.AdministratorPortalHeader);

        var manageRolePermissionsPage = await _palmsHomePage.NavigateToManageRolePermissionsPage();
        await Expect(manageRolePermissionsPage.GetManageRolePermissionPageHeader).ToHaveTextAsync("Manage role permissions");

        await manageRolePermissionsPage.FilterPalmsRole("Regional administrator");
        await _mock.GetPermissionRoleFilter(PermissionRoleFilter.GetlPermissionRoleFilterPageFixture("Audit"));
        await manageRolePermissionsPage.FilterPage("Audit");
        await manageRolePermissionsPage.ClickAuditRowRegionalAdministrator();
        await Expect(manageRolePermissionsPage.GetBtnSaveChanges).ToBeDisabledAsync();
        await Expect(manageRolePermissionsPage.GetBtnCancelChanges).ToBeDisabledAsync();

        await manageRolePermissionsPage.ClickReset();
        await manageRolePermissionsPage.FilterPalmsRole("All");
        await manageRolePermissionsPage.SelectRowPermission("Audit", "Arranger", "Enabled");
        await manageRolePermissionsPage.SelectRowPermission("Audit", "Officer", "Enabled");
        await Expect(manageRolePermissionsPage.GetBtnSaveChanges).ToBeEnabledAsync();
        await Expect(manageRolePermissionsPage.GetBtnCancelChanges).ToBeEnabledAsync();
    }

    [Test]
    public async Task VerifyNonAdminIsUnableToSeeAdminPortalURL()
    {
        var user = User.GetAusRegionUser();
        await _mock.GetAusGuestUserResponses();
        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        var profilePopper = await _palmsHomePage.ClickAvatar();
        await Expect(profilePopper.GetSwitchView).ToBeHiddenAsync();
        await profilePopper.ClickSignOut();


        await _mock.GetAusOfficerUserResponses();
        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        profilePopper = await _palmsHomePage.ClickAvatar();
        await Expect(profilePopper.GetSwitchView).ToBeHiddenAsync();
        await profilePopper.ClickSignOut();

        await _mock.GetAusArrangerUserResponses();
        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        profilePopper = await _palmsHomePage.ClickAvatar();
        await Expect(profilePopper.GetSwitchView).ToBeHiddenAsync();
        await profilePopper.ClickSignOut();

        await _mock.GetAusRequestorUserResponses();
        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        profilePopper = await _palmsHomePage.ClickAvatar();
        await Expect(profilePopper.GetSwitchView).ToBeHiddenAsync();
        await profilePopper.ClickSignOut();

        await _mock.GetAusDemandOwnerUserResponses();
        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        profilePopper = await _palmsHomePage.ClickAvatar();
        await Expect(profilePopper.GetSwitchView).ToBeHiddenAsync();
        await profilePopper.ClickSignOut();
    }

    [Test]
    public async Task VerifyUserIsTakenBackToTheUserPortal()
    {
        var globalUser = User.GetGlobalUser();
        await _mock.GetGlobalAdminUserResponses();

        await _palmsHomePage.SetSapUserId($"{globalUser.SapPersonId}");
        var adminPortalPage = await _palmsHomePage.NavigateToAdminPortalPage();
        await Expect(adminPortalPage.GetAdministratorPortalPageHeader).ToHaveTextAsync(Constants.AdministratorPortalHeader);
        await Expect(adminPortalPage.GetAdministratorPortalPageTitle).ToHaveTextAsync(Constants.PalmsAdminPortalTitle);
        await Expect(adminPortalPage.GetRegionSelector).ToBeVisibleAsync();
        await _palmsHomePage.NavigateToCustomerPortalPage();
        await Expect(_palmsHomePage.GetPageHeader).ToHaveTextAsync(Constants.HomePageHeader);
        await Expect(_palmsHomePage.GetPageTitle).ToHaveTextAsync(Constants.HomePageTitle);

        var ausRegionUser = User.GetAusRegionUser();
        await _mock.GetGlobalAdminUserResponses();

        await _palmsHomePage.SetSapUserId($"{ausRegionUser.SapPersonId}");
        await _palmsHomePage.NavigateToAdminPortalPage();
        await Expect(adminPortalPage.GetAdministratorPortalPageHeader).ToHaveTextAsync(Constants.AdministratorPortalHeader);
        await Expect(adminPortalPage.GetAdministratorPortalPageTitle).ToHaveTextAsync(Constants.PalmsAdminPortalTitle);
        await Expect(adminPortalPage.GetRegionSelector).ToBeVisibleAsync();

        await _palmsHomePage.NavigateToCustomerPortalPage();
        await Expect(_palmsHomePage.GetPageHeader).ToHaveTextAsync(Constants.HomePageHeader);
        await Expect(_palmsHomePage.GetPageTitle).ToHaveTextAsync(Constants.HomePageTitle);
    }

    [Test]
    public async Task RegionalAdministratorIsAbleToSwitchToDifferentRegionOnSelectedPages()
    {
        var user = User.GetBothAusAndCanRegionUser();
        await _mock.GetBothAusAndCanAdminUserResponses();
        await _mock.GetPermissionRoleFilter(PermissionRoleFilter.GetGlobalPermissionRoleFilterFixture);

        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        var adminPortalPage = await _palmsHomePage.NavigateToAdminPortalPage();
        await Expect(adminPortalPage.GetAdministratorPortalPageHeader).ToHaveTextAsync(Constants.AdministratorPortalHeader);
        await Expect(adminPortalPage.GetAdministratorPortalPageTitle).ToHaveTextAsync(Constants.PalmsAdminPortalTitle);
        await Expect(adminPortalPage.GetRegionSelector).ToBeVisibleAsync();

        await adminPortalPage.SwitchToAusIronOreRegion();
        await Expect(adminPortalPage.GetAdministratorPortalPageTitle).ToHaveTextAsync(Constants.AusIronOreAdminPortalTitle);

        var manageRolePermissionsPage = await _palmsHomePage.NavigateToManageRolePermissionsPage();
        await Expect(manageRolePermissionsPage.GetManageRolePermissionPageHeader).ToHaveTextAsync("Manage role permissions");

        await adminPortalPage.SwitchToCanIronOreRegion();
        await Expect(manageRolePermissionsPage.GetManageRolePermissionPageHeader).ToHaveTextAsync("Manage role permissions");
        await Expect(adminPortalPage.GetAdministratorPortalPageTitle).ToHaveTextAsync(Constants.CanIronOreAdminPortalTitle);
    }

    [Test]
    public async Task UserCancelsChangesWhenSwitchingToDifferentRegion()
    {
        var user = User.GetBothAusAndCanRegionUser();
        await _mock.GetBothAusAndCanAdminUserResponses();
        await _mock.GetPermissionRoleFilter(PermissionRoleFilter.GetGlobalPermissionRoleFilterFixture);

        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        var adminPortalPage = await _palmsHomePage.NavigateToAdminPortalPage();
        await Expect(adminPortalPage.GetAdministratorPortalPageHeader).ToHaveTextAsync(Constants.AdministratorPortalHeader);
        await Expect(adminPortalPage.GetAdministratorPortalPageTitle).ToHaveTextAsync(Constants.PalmsAdminPortalTitle);

        await adminPortalPage.SwitchToAusIronOreRegion();
        await Expect(adminPortalPage.GetAdministratorPortalPageTitle).ToHaveTextAsync(Constants.AusIronOreAdminPortalTitle);

        var manageRolePermissionsPage = await _palmsHomePage.NavigateToManageRolePermissionsPage();
        await Expect(manageRolePermissionsPage.GetManageRolePermissionPageHeader).ToHaveTextAsync("Manage role permissions");

        await manageRolePermissionsPage.FilterPalmsRole("All");
        await manageRolePermissionsPage.SelectRowPermission("Audit", "Arranger", "Enabled");
        await adminPortalPage.SwitchToCanIronOreRegion();

        await _saveOrCancelChangesPopper.ClickButtonCancel();
        await Expect(manageRolePermissionsPage.GetManageRolePermissionPageHeader).ToHaveTextAsync("Manage role permissions");
        await Expect(adminPortalPage.GetAdministratorPortalPageTitle).ToHaveTextAsync(Constants.AusIronOreAdminPortalTitle);
    }

    [Test]
    public async Task UserClearsChangesWhenSwitchingToDifferentRegion()
    {
        var user = User.GetBothAusAndCanRegionUser();
        await _mock.GetBothAusAndCanAdminUserResponses();
        await _mock.GetPermissionRoleFilter(PermissionRoleFilter.GetGlobalPermissionRoleFilterFixture);

        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        var adminPortalPage = await _palmsHomePage.NavigateToAdminPortalPage();
        await Expect(adminPortalPage.GetAdministratorPortalPageHeader).ToHaveTextAsync(Constants.AdministratorPortalHeader);
        await Expect(adminPortalPage.GetAdministratorPortalPageTitle).ToHaveTextAsync(Constants.PalmsAdminPortalTitle);

        await adminPortalPage.SwitchToAusIronOreRegion();
        await Expect(adminPortalPage.GetAdministratorPortalPageTitle).ToHaveTextAsync(Constants.AusIronOreAdminPortalTitle);

        var manageRolePermissionsPage = await _palmsHomePage.NavigateToManageRolePermissionsPage();
        await Expect(manageRolePermissionsPage.GetManageRolePermissionPageHeader).ToHaveTextAsync("Manage role permissions");

        await manageRolePermissionsPage.FilterPalmsRole("All");
        await manageRolePermissionsPage.SelectRowPermission("Audit", "Arranger", "Enabled");
        await adminPortalPage.SwitchToCanIronOreRegion();

        await _saveOrCancelChangesPopper.ClickButtonClearChanges();
        await Expect(manageRolePermissionsPage.GetManageRolePermissionPageHeader).ToHaveTextAsync("Manage role permissions");
        await Expect(adminPortalPage.GetAdministratorPortalPageTitle).ToHaveTextAsync(Constants.CanIronOreAdminPortalTitle);
    }

    [Test]
    public async Task SaveChangesWhenSwitchingToDifferentRegion()
    {
        var user = User.GetBothAusAndCanRegionUser();
        await _mock.GetBothAusAndCanAdminUserResponses();
        await _mock.GetPermissionRoleFilter(PermissionRoleFilter.GetGlobalPermissionRoleFilterFixture);

        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        var adminPortalPage = await _palmsHomePage.NavigateToAdminPortalPage();
        await Expect(adminPortalPage.GetAdministratorPortalPageHeader).ToHaveTextAsync(Constants.AdministratorPortalHeader);
        await Expect(adminPortalPage.GetAdministratorPortalPageTitle).ToHaveTextAsync(Constants.PalmsAdminPortalTitle);

        await adminPortalPage.SwitchToAusIronOreRegion();
        await Expect(adminPortalPage.GetAdministratorPortalPageTitle).ToHaveTextAsync(Constants.AusIronOreAdminPortalTitle);

        var manageRolePermissionsPage = await _palmsHomePage.NavigateToManageRolePermissionsPage();
        await Expect(manageRolePermissionsPage.GetManageRolePermissionPageHeader).ToHaveTextAsync("Manage role permissions");

        await manageRolePermissionsPage.FilterPalmsRole("All");
        await manageRolePermissionsPage.SelectRowPermission("Audit", "Arranger", "Enabled");
        await adminPortalPage.SwitchToCanIronOreRegion();
        await Expect(_saveOrCancelChangesPopper.GetSaveOrCancelChangesHeader).ToBeVisibleAsync();

        await _saveOrCancelChangesPopper.ClickButtonSaveChanges();
        await Expect(manageRolePermissionsPage.GetManageRolePermissionPageHeader).ToHaveTextAsync("Manage role permissions");
        await Expect(adminPortalPage.GetAdministratorPortalPageTitle).ToHaveTextAsync(Constants.AusIronOreAdminPortalTitle);

        await adminPortalPage.SwitchToAusIronOreRegion();
        await Expect(adminPortalPage.GetAdministratorPortalPageTitle).ToHaveTextAsync(Constants.AusIronOreAdminPortalTitle);
        await manageRolePermissionsPage.FilterPalmsRole("All");
        await manageRolePermissionsPage.SelectRowPermission("Audit", "Arranger", "Enabled");
        await manageRolePermissionsPage.ClickReset();
    }

    [Test]
    public async Task RegionalAdministratorIsNotAbleToAccessManageRolePage()
    {
        var user = User.GetAusRegionUser();
        await _mock.GetAusRegionalAdminUserResponses();

        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        var adminPortalPage = await _palmsHomePage.NavigateToAdminPortalPage();
        await Expect(adminPortalPage.GetAdministratorPortalPageHeader).ToHaveTextAsync(Constants.AdministratorPortalHeader);
        var sideBar = await _palmsHomePage.ClickSideBar();
        await Expect(sideBar.GetSideMenuManageRoles).ToBeHiddenAsync();
    }
}
