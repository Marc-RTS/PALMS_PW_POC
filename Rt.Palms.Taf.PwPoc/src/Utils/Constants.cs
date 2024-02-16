using System;

public static class Constants
{
    public const string PageBanner = "PALMS";

    //Page Headers
    public const string HomePageHeader = "Welcome To PALMS";
    public const string SearchUserProfilePageHeader = "Search user profile";
    public const string SearchCustomerProfilePageHeader = "Search customer profile";
    public const string AdministratorPortalHeader = "Administrator Portal";

    public const string ManageUserRolesHeader = "Manage user roles";
    public const string ViewUserHistoryHeader = "View user history";

    //Page Titles
    public const string HomePageTitle = "PALMS";
    public const string PalmsAdminPortalTitle = "PALMS  - Administrator Portal";
    public const string GlobalAdminPortalTitle = "PALMS Global - Administrator Portal";
    public const string AusIronOreAdminPortalTitle = "PALMS Australia Iron Ore - Administrator Portal";
    public const string CanIronOreAdminPortalTitle = "PALMS Canada Iron Ore - Administrator Portal";

    //Messages
    public const string MsgYouAreAnAdmin = "You are an Admin User!";
    public const string MsgNoProfilesWereFound = "=No profiles were found";

    public static string adminAuth = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\", @"src", @"Utils", @".auth", "admin.json");
    public static string userFixturePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\", @"src", @"Fixtures", @"DataFixture", @"User", "FxUser.json");
    public static string rbacFixturePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\", @"src", @"Fixtures", @"DataFixture", @"User", "FxRbac.json");
    public static string permissionUserFixturePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\", @"src", @"Fixtures", @"DataFixture", @"User", "FxPermissionUser.json");
    public static string predictiveSearchFixturePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\", @"src", @"Fixtures", @"DataFixture", @"UserProfile", "FxPredictiveSearch.json");
    public static string userFindFixturePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\", @"src", @"Fixtures", @"DataFixture", @"UserProfile", "FxUserFind.json");
    public static string permissionRoleFilterFixturePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\", @"src", @"Fixtures", @"DataFixture", @"PermissionRole", "FxPermissionRoleFilter.json");
    public static string permissionRoleFilterRegionalAdminFixturePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\", @"src", @"Fixtures", @"DataFixture", @"PermissionRole", "FxPermissionRoleFilterRegionalAdmin.json");

}
