using Microsoft.Playwright;
using Rt.Palms.Taf.PwPoc.src.Fixtures.Implementation;
using Rt.Palms.Taf.PwPoc.src.Pages;
using Rt.Palms.Taf.PwPoc.src.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using NUnit.Allure.Core;

namespace Rt.Palms.Taf.PwPoc.src.Tests.UI.Administration;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
[AllureNUnit]
internal class SuspendUserTest : BaseTest
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
    public async Task SuspendButtonDisabledByDefaultAndForCurrentUser()
    {
        //@TC-19222
        //Scenario Outline: Suspend button disabled by default and for current user
        //    And user logs in as 'Australia - Iron Ore regional administrator'
        //    And the user swaps portals
        //    Then user is on the 'AdministratorPortal' page
        //    When the user navigates to the 'Manage user roles' page
        //    And user is on the 'ManageUserRoles' page
        //    Then the visibility of the element 'SuspendProfileButton' is true
        //    And element 'SuspendProfileButton' is 'disabled'
        //    When user enters '9400959' into 'SapNumberSearch'
        //    Then element 'SuspendProfileButton' is 'disabled'
        var user = User.GetAusRegionUser();
        await _mock.GetAusSuspendedUserResponses();

        await _palmsHomePage.SetSapUserId($"{user.SapPersonId}");
        //var adminPortalPage = await _palmsHomePage.NavigateToAdminPortalPage();
        //await Expect(adminPortalPage.GetAdministratorPortalPageHeader).ToHaveTextAsync("Administrator Portal");

        //var manageRolePermissionsPage = await _palmsHomePage.NavigateToManageUserRolesPage();

        //await Expect(manageRolePermissionsPage.GetManageUserRolesPageHeader).ToContainTextAsync(Constants.ManageUserRolesHeader);

    }
    public async Task UserCanBeSuspendedAndUnsuspended()
    {
        //    @TC-19222
        //    @TC-19555
        //    @TC-19300
        //    Scenario Outline: User can be suspended and unsuspended
        //        And user logs in as 'Global administrator'
        //        And the user swaps portals
        //        Then user is on the 'AdministratorPortal' page
        //        And the user can select the value 'CanadaRegionOption' from the 'AdminPortalRegionSelector' region dropdown
        //        When the user navigates to the 'Manage user roles' page
        //    And user is on the 'ManageUserRoles' page
        //        Then the visibility of the element 'SuspendProfileButton' is true
        //        And the exact text is displayed for the respective element
        //          | elementName          | text    |
        //          | SuspendProfileButton | Suspend |
        //        When user enters '1223456' into 'SapNumberSearch'
        //        Then element 'SuspendProfileButton' is 'enabled'
        //        When user clicks on the 'SuspendProfileButton' element
        //        And user clicks on the 'SuspendConfirmButton' element
        //        Then the visibility of the element 'SuspendedSidebar' is true
        //        And the checkboxes state is
        //          | Field               | Value   |
        //          | SuspendRoleCheckbox | checked |
        //        And the exact text is displayed for the respective element
        //          | elementName          | text      |
        //          | SuspendProfileButton | Unsuspend |
        //        When user clicks on the 'SuspendProfileButton' element
        //        And user clicks on the 'SuspendConfirmButton' element
        //        Then the visibility of the element 'SuspendedSidebar' is false
        //        Then the exact text is displayed for the respective element
        //          | elementName          | text    |
        //          | SuspendProfileButton | Suspend |
        //        And the checkboxes state is
        //          | Field               | Value     |
        //          | SuspendRoleCheckbox | unchecked |
    }
}
