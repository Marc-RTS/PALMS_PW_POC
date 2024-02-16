using Microsoft.Playwright;
using Rt.Palms.Taf.PwPoc.src.Fixtures.Implementation;

namespace Rt.Palms.Taf.PwPoc.src.Support;

internal class Mock
{
    private IPage _page;
    public Mock(IPage page) => _page = page;

    public async Task GetUser(string sapUserId, string fixture)
    {
        await RouteFullFill($"**/api/user/{sapUserId}", fixture);
    }

    public async Task GetRBAC(string palmsUserGuid, string fixture)
    {
        await RouteFullFill($"**/api/rbac/{palmsUserGuid}", fixture);
    }

    public async Task GetPermissionsUser(string fixture)
    {
        await RouteFullFill($"**/api/permission/user", fixture);
    }
    public async Task GetAusRegionalAdminUserResponses()
    {
        await GetUser($"{User.GetAusRegionUser().SapPersonId}", User.GetAusRegionUserFixture);
        await GetRBAC($"{User.GetAusRegionUser().PalmsUserGuid}", Rbac.GetAusRegionalAdminRbacFixture);
        await GetPermissionsUser(PermissionUser.GetAusRegionalAdminPermissionUserFixture);
    }

    public async Task GetCanRegionalAdminUserResponses()
    {
        await GetUser($"{User.GetCanRegionUser().SapPersonId}", User.GetCanRegionUserFixture);
        await GetRBAC($"{User.GetCanRegionUser().PalmsUserGuid}", Rbac.GetCanRegionalAdminRbacFixture);
        await GetPermissionsUser(PermissionUser.GetCanRegionalAdminPermissionUserFixture);
    }

    public async Task GetBothAusAndCanAdminUserResponses()
    {
        await GetUser($"{User.GetBothAusAndCanRegionUser().SapPersonId}", User.GetBothAusAndCanRegionUserFixture);
        await GetRBAC($"{User.GetBothAusAndCanRegionUser().PalmsUserGuid}", Rbac.GetBothAusAndCanRegionalAdminRbacFixture);
        await GetPermissionsUser(PermissionUser.GetBothCanadaAndAusAdminPermissionUserFixture);
    }

    public async Task GetGlobalAdminUserResponses()
    {
        await GetUser($"{User.GetGlobalUser().SapPersonId}", User.GetGlobalAdminUserFixture);
        await GetRBAC($"{User.GetGlobalUser().PalmsUserGuid}", Rbac.GetGlobalAdminRbacFixture);
        await GetPermissionsUser(PermissionUser.GetGlobalAdminPermissionUserFixture);
    }
    public async Task GetAusGuestUserResponses()
    {
        await GetUser($"{User.GetAusRegionUser().SapPersonId}", User.GetAusRegionUserFixture);
        await GetRBAC($"{User.GetAusRegionUser().PalmsUserGuid}", Rbac.GetRbacNoRegionsFixture);
        await GetPermissionsUser(PermissionUser.GetAusGuestPermissionUserFixture);
    }
    public async Task GetAusOfficerUserResponses()
    {
        await GetUser($"{User.GetAusRegionUser().SapPersonId}", User.GetAusRegionUserFixture);
        await GetRBAC($"{User.GetAusRegionUser().PalmsUserGuid}", Rbac.GetRbacNoRegionsFixture);
        await GetPermissionsUser(PermissionUser.GetAusOfficerPermissionUserFixture);
    }

    public async Task GetAusArrangerUserResponses()
    {
        await GetUser($"{User.GetAusRegionUser().SapPersonId}", User.GetAusRegionUserFixture);
        await GetRBAC($"{User.GetAusRegionUser().PalmsUserGuid}", Rbac.GetRbacNoRegionsFixture);
        await GetPermissionsUser(PermissionUser.GetAusArrangerPermissionUserFixture);
    }

    public async Task GetAusRequestorUserResponses()
    {
        await GetUser($"{User.GetAusRegionUser().SapPersonId}", User.GetAusRegionUserFixture);
        await GetRBAC($"{User.GetAusRegionUser().PalmsUserGuid}", Rbac.GetRbacNoRegionsFixture);
        await GetPermissionsUser(PermissionUser.GetAusRequestorPermissionUserFixture);
    }
    public async Task GetAusDemandOwnerUserResponses()
    {
        await GetUser($"{User.GetAusRegionUser().SapPersonId}", User.GetAusRegionUserFixture);
        await GetRBAC($"{User.GetAusRegionUser().PalmsUserGuid}", Rbac.GetRbacNoRegionsFixture);
        await GetPermissionsUser(PermissionUser.GetAusDemandOwnerPermissionUserFixture);
    }
    public async Task GetAusSuspendedUserResponses()
    {
        await GetUser($"{User.GetAusRegionUser().SapPersonId}", User.GetAusRegionUserFixture);
        await GetRBAC($"{User.GetAusRegionUser().PalmsUserGuid}", Rbac.GetRbacNoRegionsFixture);
        await GetPermissionsUser(PermissionUser.GetAusSuspendedPermissionUserFixture);
    }

    public async Task GetPermissionRoleFilter(string fixture)
    {
        await RouteFullFill($"**/api/permission/role/filter", fixture);

    }
    public async Task GetPredictiveSearch(string fixture)
    {
        await RouteFullFill($"**/api/user/predictivesearch", fixture); 
    }
    public async Task GetUserFind(string fixture)
    {
        await RouteFullFill($"**/api/user/find", fixture);
    }

    public async Task RouteFullFill(string url, string fixture)
    {
        await _page.RouteAsync(url, async route =>
        {
            await route.FulfillAsync(new()
            {
                Status = 200,
                Body = fixture,
                ContentType = "application/json; charset=utf-8",
            });
                
        });
    }
}
