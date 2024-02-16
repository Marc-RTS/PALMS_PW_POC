using NUnit.Allure.Core;
using Rt.Palms.Taf.PwPoc.src.Fixtures.Implementation;
using Rt.Palms.Taf.PwPoc.src.Pages;
using Rt.Palms.Taf.PwPoc.src.Support;


namespace Rt.Palms.Taf.PwPoc.src.Tests.UI.Administration;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
[AllureNUnit]
public class SearchUserProfileAndAdministratorPortalTest : BaseTest
{
    private static Mock _mock;
    private static LoginPage _loginPage;
    private static PalmsHomePage _palmsHomePage;

    [SetUp]
    public async Task Setup()
    {
        _mock = new Mock(Page);
        _loginPage = new LoginPage(Page);
        _palmsHomePage = new PalmsHomePage(Page);
        await _loginPage.OpenUrl();
    }

    [Test]
    public async Task VerifyUserExistInSapOnlyWontBeReturnedByTheSystem()
    {
        var user = User.GetAusRegionUser();
        var userFind = UserFind.GetDefaultUserFind;
        string userToSearch = $"{userFind.Results[0].SapPersonId}";
        string NoProfileFoundFixture = UserFind.GetUserFindNoProfileFoundFixture;
        await _mock.GetAusRegionalAdminUserResponses();
        await _mock.GetPredictiveSearch("[]");
        await _mock.GetUserFind(NoProfileFoundFixture);

        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        var profilePopper = await _palmsHomePage.ClickAvatar();
        await profilePopper.ClickAdministration();
        var sideBar = await _palmsHomePage.ClickSideBar();
        var searchUserProfilePage = await sideBar.NavigateToSearchUserProfilePage();

        await searchUserProfilePage.SearchUserProfile(userToSearch);
        await Expect(searchUserProfilePage.GetAlertMessageContents).ToContainTextAsync("No profiles were found");
    }

    [Test]
    public async Task VerifyUserExistInPalmsIsReturnedByTheSystem()
    {
        var user = User.GetAusRegionUser();
        var userFind = UserFind.GetDefaultUserFind;
        await _mock.GetAusRegionalAdminUserResponses();
        await _mock.GetUserFind(UserFind.GetDefaultUserFindFixture);

        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        var profilePopper = await _palmsHomePage.ClickAvatar();
        await profilePopper.ClickAdministration();
        var sideBar = await _palmsHomePage.ClickSideBar();
        var searchUserProfilePage = await sideBar.NavigateToSearchUserProfilePage();
        var searchResult = await searchUserProfilePage.SearchUserProfile($"{userFind.Results[0].SapPersonId}");

        await Expect(searchResult.GetBtnCreateCustomerProfile).ToBeHiddenAsync();
        await Expect(searchResult.GetChkboxPalmsOnly).ToBeHiddenAsync();
        await Expect(searchResult.GetListSearchResult
            .Filter(new() { HasText = $"{userFind.Results[0].LastName}, {userFind.Results[0].FirstName} (prefers {userFind.Results[0].PreferredName})" })).ToBeVisibleAsync();
        await Expect(searchResult.GetListSearchResult
            .Filter(new() { HasText = $"{userFind.Results[0].Position}" })).ToBeVisibleAsync();
        await Expect(searchResult.GetListSearchResult
            .Filter(new() { HasText = $"{userFind.Results[0].PersonnelSubArea}" })).ToBeVisibleAsync();
        await Expect(searchResult.GetListSearchResult
            .Filter(new() { HasText = $"Personnel number:{userFind.Results[0].SapPersonnelNumber}" })).ToBeVisibleAsync();
        await Expect(searchResult.GetListSearchResult
            .Filter(new() { HasText = $"Person ID:{userFind.Results[0].SapPersonId}" })).ToBeVisibleAsync();
    }

    [Test]
    public async Task AC12VerifyUserCanNavigateToTheManageUserRolesPageAndSearchedUserDataIsDisplayed()
    {
        var user = User.GetAusRegionUser();
        var userFind = UserFind.GetDefaultUserFind;
        await _mock.GetAusRegionalAdminUserResponses();
        await _mock.GetUserFind(UserFind.GetDefaultUserFindFixture);

        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        await Expect(_palmsHomePage.GetMessageContent).ToContainTextAsync(Constants.MsgYouAreAnAdmin);
        var profilePopper = await _palmsHomePage.ClickAvatar();
        await Expect(profilePopper.GetName).ToContainTextAsync($"{user.FirstName} {user.LastName}");
        var adminPortal = await profilePopper.ClickAdministration();
        await Expect(adminPortal.GetAdministratorPortalPageHeader).ToContainTextAsync(Constants.AdministratorPortalHeader);
        var sideBar = await _palmsHomePage.ClickSideBar();
        var searchUserProfilePage = await sideBar.NavigateToSearchUserProfilePage();
        await Expect(searchUserProfilePage.GetUserCustomerProfileHeader).ToContainTextAsync(Constants.SearchUserProfilePageHeader);
        var searchResult = await searchUserProfilePage.SearchUserProfile($"{userFind.Results[0].SapPersonId}");

        await Expect(searchResult.GetListSearchResult
            .Filter(new() { HasText = $"{userFind.Results[0].LastName}, {userFind.Results[0].FirstName} (prefers {userFind.Results[0].PreferredName})" }))
            .ToBeVisibleAsync();
        await Expect(searchResult.GetListSearchResult
            .Filter(new() { HasText = $"{userFind.Results[0].Position}" }))
            .ToBeVisibleAsync();
        await Expect(searchResult.GetListSearchResult
            .Filter(new() { HasText = $"{userFind.Results[0].PersonnelSubArea}" }))
            .ToBeVisibleAsync();
        await Expect(searchResult.GetListSearchResult
            .Filter(new() { HasText = $"Personnel number:{userFind.Results[0].SapPersonnelNumber}" }))
            .ToBeVisibleAsync();
        await Expect(searchResult.GetListSearchResult
            .Filter(new() { HasText = $"Person ID:{userFind.Results[0].SapPersonId}" }))
            .ToBeVisibleAsync();

        var manageUserRoles = await searchResult.NavigateToManageUserRolePage($"{userFind.Results[0].SapPersonId}");
        await Expect(manageUserRoles.GetManageUserRolesPageHeader).ToContainTextAsync(Constants.ManageUserRolesHeader);
    }

    [Test]
    public async Task AC34VerifyUserCanNavigateToTheViewUserHistoryAndSearchedUserDataIsDisplayed()
    {
        var user = User.GetAusRegionUser();
        var userFind = UserFind.GetDefaultUserFind;
        await _mock.GetAusRegionalAdminUserResponses();
        await _mock.GetUserFind(UserFind.GetDefaultUserFindFixture);

        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        await Expect(_palmsHomePage.GetMessageContent).ToContainTextAsync(Constants.MsgYouAreAnAdmin);
        var profilePopper = await _palmsHomePage.ClickAvatar();
        await Expect(profilePopper.GetName).ToContainTextAsync($"{user.FirstName} {user.LastName}");
        var adminPortal = await profilePopper.ClickAdministration();
        await Expect(adminPortal.GetAdministratorPortalPageHeader).ToContainTextAsync(Constants.AdministratorPortalHeader);
        var sideBar = await _palmsHomePage.ClickSideBar();
        var searchUserProfilePage = await sideBar.NavigateToSearchUserProfilePage();
        await Expect(searchUserProfilePage.GetUserCustomerProfileHeader).ToContainTextAsync(Constants.SearchUserProfilePageHeader);
        var searchResult = await searchUserProfilePage.SearchUserProfile($"{userFind.Results[0].SapPersonId}");

        await Expect(searchResult.GetListSearchResult
            .Filter(new() { HasText = $"{userFind.Results[0].LastName}, {userFind.Results[0].FirstName} (prefers {userFind.Results[0].PreferredName})" }))
            .ToBeVisibleAsync();
        await Expect(searchResult.GetListSearchResult
            .Filter(new() { HasText = $"{userFind.Results[0].Position}" }))
            .ToBeVisibleAsync();
        await Expect(searchResult.GetListSearchResult
            .Filter(new() { HasText = $"{userFind.Results[0].PersonnelSubArea}" }))
            .ToBeVisibleAsync();
        await Expect(searchResult.GetListSearchResult
            .Filter(new() { HasText = $"Personnel number:{userFind.Results[0].SapPersonnelNumber}" }))
            .ToBeVisibleAsync();
        await Expect(searchResult.GetListSearchResult
            .Filter(new() { HasText = $"Person ID:{userFind.Results[0].SapPersonId}" }))
            .ToBeVisibleAsync();

        var viewUserHistory = await searchResult.NavigateToViewUserHistoryPage($"{userFind.Results[0].SapPersonId}");
        await Expect(viewUserHistory.GetViewUserHistoryPageHeader).ToContainTextAsync(Constants.ViewUserHistoryHeader);
    }
}
