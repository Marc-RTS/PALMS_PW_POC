using NUnit.Allure.Core;
using Rt.Palms.Taf.PwPoc.src.Fixtures.Implementation;
using Rt.Palms.Taf.PwPoc.src.Pages;
using Rt.Palms.Taf.PwPoc.src.Support;

namespace Rt.Palms.Taf.PwPoc.src.Tests.UI.Administration;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
[AllureNUnit]
public class SearchUserProfileUpdatedTest : BaseTest
{
    private static Mock _mock;
    private static PalmsHomePage _palmsHomePage;
    private static LoginPage _loginPage;

    [SetUp]
    public async Task Setup()
    {
        _loginPage = new LoginPage(Page);
        _palmsHomePage = new PalmsHomePage(Page);
        _mock = new Mock(Page);
        await _loginPage.OpenUrl();
    }

    [Test]
    public async Task VerifySearchedUserDataIsDisplayed()
    {
        var user = User.GetAusRegionUser();
        var userFind = UserFind.GetDefaultUserFind;
        await _mock.GetAusRegionalAdminUserResponses();
        await _mock.GetUserFind(UserFind.GetDefaultUserFindFixture);

        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        var searchUserProfilePage = await _palmsHomePage.NavigateToSearchUserProfilePage();
        var searchResult = await searchUserProfilePage.SearchUserProfile($"{userFind.Results[0].SapPersonId}");

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
    public async Task VerifyPredictiveSearch()
    {
        var user = User.GetAusRegionUser();
        var userFind = UserFind.GetDefaultUserFind;
        await _mock.GetAusRegionalAdminUserResponses();
        await _mock.GetPredictiveSearch(PredictiveSearch.GetDefaultUserFindPredictiveSearchFixture);

        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        var searchUserProfilePage = await _palmsHomePage.NavigateToSearchUserProfilePage();

        await searchUserProfilePage.EnterSearchInput($"{userFind.Results[0].SapPersonId}");

        await Expect(searchUserProfilePage.GetPredictiveSearchResult).ToHaveTextAsync($"{userFind.Results[0].LastName}, {userFind.Results[0].FirstName} (prefers {userFind.Results[0].PreferredName})");
    }

    [Test]
    public async Task VerifyUserCanNavigateToTheManageUserRolesPage()
    {
        var user = User.GetAusRegionUser();
        var userFind = UserFind.GetDefaultUserFind;
        await _mock.GetUserFind(UserFind.GetDefaultUserFindFixture);
        await _mock.GetAusRegionalAdminUserResponses();

        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        var searchUserProfilePage = await _palmsHomePage.NavigateToSearchUserProfilePage();
        var searchResult = await searchUserProfilePage.SearchUserProfile($"{userFind.Results[0].SapPersonId}");

        var manageUserRoles = await searchResult.NavigateToManageUserRolePage($"{userFind.Results[0].SapPersonId}");
        await Expect(manageUserRoles.GetManageUserRolesPageHeader).ToContainTextAsync(Constants.ManageUserRolesHeader);
    }

    [Test]
    public async Task VerifyUserCanNavigateToTheViewUserHistoryPage()
    {
        var user = User.GetAusRegionUser();
        var userFind = UserFind.GetDefaultUserFind;
        await _mock.GetAusRegionalAdminUserResponses();
        await _mock.GetUserFind(UserFind.GetDefaultUserFindFixture);

        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        var searchUserProfilePage = await _palmsHomePage.NavigateToSearchUserProfilePage();
        var searchResult = await searchUserProfilePage.SearchUserProfile($"{userFind.Results[0].SapPersonId}");

        var viewUserHistory = await searchResult.NavigateToViewUserHistoryPage($"{userFind.Results[0].SapPersonId}");
        await Expect(viewUserHistory.GetViewUserHistoryPageHeader).ToContainTextAsync(Constants.ViewUserHistoryHeader);
    }

    [Test]
    public async Task VerifyUserSideBarDetails()
    {
        var user = User.GetAusRegionUser();
        var userFind = UserFind.GetDefaultUserFind;
        await _mock.GetAusRegionalAdminUserResponses();
        await _mock.GetUserFind(UserFind.GetDefaultUserFindFixture);

        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        var searchUserProfilePage = await _palmsHomePage.NavigateToSearchUserProfilePage();
        var searchContainer = await searchUserProfilePage.SearchUserProfile($"{userFind.Results[0].SapPersonId}");
        var profileSidebar = await searchContainer.ClickSearchResultItemButton($"{userFind.Results[0].SapPersonId}");

        await Expect(profileSidebar.GetName).ToHaveTextAsync($"{userFind.Results[0].LastName.ToUpper()}, {userFind.Results[0].FirstName}");
        await Expect(profileSidebar.GetPosition).ToContainTextAsync($"{userFind.Results[0].Position}");
        //await Expect(searchUserProfilePage.profileSideBar).ToHaveTextAsync($"{searchResult.Results[0].PersonalMobileNumber}"); // bug- inconsistent schema
        await Expect(profileSidebar.GetPersonnelNumber).ToHaveTextAsync($"{userFind.Results[0].SapPersonnelNumber}");
        if (!string.IsNullOrEmpty($"{userFind.Results[0].QantasFrequentFlyerNumber}"))
        {
            await Expect(profileSidebar.GetQantasFrequentFlyer).ToHaveTextAsync($"{userFind.Results[0].QantasFrequentFlyerNumber}");
        }
        if (!string.IsNullOrEmpty($"{userFind.Results[0].QantasFrequentFlyerNumber}"))
        {
            await Expect(profileSidebar.GetVirginFrequentFlyer).ToHaveTextAsync($"{userFind.Results[0].VirginFrequentFlyerNumber}");
        }
        if (!string.IsNullOrEmpty($"{userFind.Results[0].QantasFrequentFlyerNumber}"))
        {
            await Expect(profileSidebar.GetLeaderName).ToHaveTextAsync($"{userFind.Results[0].Leader}");
            await Expect(profileSidebar.GetLeaderPersonnelNumber).ToHaveTextAsync($"{userFind.Results[0].LeaderId}");
            await Expect(profileSidebar.GetLeaderRole).ToHaveTextAsync($"{userFind.Results[0].LeaderRole}");
        }
        await Expect(profileSidebar.GetOrgUnitName).ToHaveTextAsync($"{userFind.Results[0].OrganisationalUnit}");
        await Expect(profileSidebar.GetOrgUnitId).ToHaveTextAsync($"{userFind.Results[0].OrganisationalUnitId}");
        await Expect(profileSidebar.GetPersonnelArea).ToHaveTextAsync($"{userFind.Results[0].PersonnelArea}");
        await Expect(profileSidebar.GetPersonnelAreaId).ToHaveTextAsync($"{userFind.Results[0].PersonnelAreaId}");
        await Expect(profileSidebar.GetEmployer).ToHaveTextAsync($"{userFind.Results[0].Employer}");
        await Expect(profileSidebar.GetEmployerId).ToHaveTextAsync($"{userFind.Results[0].EmployerId}");
        await Expect(profileSidebar.GetCostCode).ToHaveTextAsync($"{userFind.Results[0].PalmsCostCode}");
    }
}
