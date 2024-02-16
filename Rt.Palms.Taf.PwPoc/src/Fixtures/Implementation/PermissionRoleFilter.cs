using Rt.Palms.Taf.PwPoc.src.Fixtures.Models;
using Rt.Palms.Taf.PwPoc.src.Support;



namespace Rt.Palms.Taf.PwPoc.src.Fixtures.Implementation;

internal class PermissionRoleFilter
{
    private static string GetPermissionRoleFilterFx => Helpers.ReadAllTextFromFile(Constants.permissionRoleFilterFixturePath);
    private static string GetPermissionRoleFilterRegionalFx => Helpers.ReadAllTextFromFile(Constants.permissionRoleFilterRegionalAdminFixturePath);
    public static string GetGlobalPermissionRoleFilterFixture => Helpers.Serialize(GetGlobalPermissionRoleFilter());
    public static FxPermissionRoleFilter[] GetGlobalPermissionRoleFilter()
    {
        var permissionRole = Helpers.Deserialize<FxPermissionRoleFilter[]>(GetPermissionRoleFilterFx) ?? [];
        return permissionRole;
    }

    public static string GetRegionalPermissionRoleFilterFixture(string permissionKey)
    {
        return Helpers.Serialize(GetRegionalPermissionRoleFilter(permissionKey));
    }
    public static FxPermissionRoleFilter[] GetRegionalPermissionRoleFilter(string permissionKey)
    {
        var permissionRole = Helpers.Deserialize<FxPermissionRoleFilter[]>(GetPermissionRoleFilterFx) ?? [];
        foreach (var filter in permissionRole)
        {
            filter.Permissions = filter.Permissions.Where(x => x.Key == permissionKey).ToArray();
        }
        return permissionRole;
    }

    public static string GetlPermissionRoleFilterDomainCustomerFixture(string domain)
    {
        return Helpers.Serialize(GetlPermissionRoleFilterDomainCustomer(domain));
    }
    public static FxPermissionRoleFilter[] GetlPermissionRoleFilterDomainCustomer(string domain)
    {
        var permissionRole = Helpers.Deserialize<FxPermissionRoleFilter[]>(GetPermissionRoleFilterFx) ?? [];
        permissionRole = permissionRole.Where(x => x.Domain == domain).ToArray();
        return permissionRole;
    }
    public static string GetlPermissionRoleFilterPageFixture(string page)
    {
        return Helpers.Serialize(GetlPermissionRoleFilterPage(page));
    }
    public static FxPermissionRoleFilter[] GetlPermissionRoleFilterPage(string page)
    {
        var permissionRole = Helpers.Deserialize<FxPermissionRoleFilter[]>(GetPermissionRoleFilterFx) ?? [];
        permissionRole = permissionRole.Where(x => x.Page == page).ToArray();
        return permissionRole;
    }
    public static string GetlPermissionRoleFilterAttributeTypeFixture(string attributeType)
    {
        return Helpers.Serialize(GetlPermissionRoleFilterAttributeType(attributeType));
    }
    public static FxPermissionRoleFilter[] GetlPermissionRoleFilterAttributeType(string attributeType)
    {
        var permissionRole = Helpers.Deserialize<FxPermissionRoleFilter[]>(GetPermissionRoleFilterFx) ?? [];
        permissionRole = permissionRole.Where(x => x.AttributeType == attributeType).ToArray();
        return permissionRole;
    }
    public static string GetlPermissionRoleFilterAttributeNameFixture(string attributeName)
    {
        return Helpers.Serialize(GetlPermissionRoleFilterAttributeName(attributeName));
    }
    public static FxPermissionRoleFilter[] GetlPermissionRoleFilterAttributeName(string attributeName)
    {
        var permissionRole = Helpers.Deserialize<FxPermissionRoleFilter[]>(GetPermissionRoleFilterFx) ?? [];
        permissionRole = permissionRole.Where(x => x.AttributeName == attributeName).ToArray();
        return permissionRole;
    }
}
