
using Rt.Palms.Taf.PwPoc.src.Fixtures.Models;
using Rt.Palms.Taf.PwPoc.src.Support;


namespace Rt.Palms.Taf.PwPoc.src.Fixtures.Implementation;

internal class PermissionUser
{
    private static string GetPermissionUserFx => Helpers.ReadAllTextFromFile(Constants.permissionUserFixturePath);
    public static string GetCanRegionalAdminPermissionUserFixture => Helpers.Serialize(GetCanRegionalAdminPermissionUser());
    public static string GetAusRegionalAdminPermissionUserFixture => Helpers.Serialize(GetCanRegionalAdminPermissionUser());
    public static string GetBothCanadaAndAusAdminPermissionUserFixture => Helpers.Serialize(GetBothCanadaAndAusAdminPermissionUser());
    public static string GetGlobalAdminPermissionUserFixture => Helpers.Serialize(GetGlobalAdminPermissionUser());
    public static string GetAusGuestPermissionUserFixture => Helpers.Serialize(GetAusGuestPermissionUser());
    public static string GetAusOfficerPermissionUserFixture => Helpers.Serialize(GetAusOfficerPermissionUser());
    public static string GetAusArrangerPermissionUserFixture => Helpers.Serialize(GetAusArrangerPermissionUser());
    public static string GetAusDemandOwnerPermissionUserFixture => Helpers.Serialize(GetAusDemandOwnerPermissionUser());
    public static string GetAusRequestorPermissionUserFixture => Helpers.Serialize(GetAusRequestorPermissionUser());
    public static string GetAusSuspendedPermissionUserFixture => Helpers.Serialize(GetAusSuspendedPermissionUser());

    public static FxPermissionUser GetCanRegionalAdminPermissionUser()
    {
        var userPermission = Helpers.Deserialize<FxPermissionUser>(GetPermissionUserFx);

        userPermission.UserRoles.First(
            UserRole => UserRole.RoleName == "Regional administrator"
            && UserRole.RoleTags == "regCANpgIRO").IsAssigned = true;

        return userPermission;
    }
    public static FxPermissionUser GetAusRegionalAdminPermissionUser()
    {
        var userPermission = Helpers.Deserialize<FxPermissionUser>(GetPermissionUserFx);

        userPermission.UserRoles.First(
            UserRole => UserRole.RoleName == "Regional administrator"
            && UserRole.RoleTags == "regAUSpgIRO").IsAssigned = true;

        return userPermission;
    }
    public static FxPermissionUser GetBothCanadaAndAusAdminPermissionUser()
    {
        var userPermission = Helpers.Deserialize<FxPermissionUser>(GetPermissionUserFx);

        userPermission.UserRoles.First(
            UserRole => UserRole.RoleName == "Regional administrator"
            && UserRole.RoleTags == "regCANpgIRO").IsAssigned = true;

        userPermission.UserRoles.First(
            UserRole => UserRole.RoleName == "Regional administrator"
            && UserRole.RoleTags == "regAUSpgIRO").IsAssigned = true;

        return userPermission;
    }

    public static FxPermissionUser GetGlobalAdminPermissionUser()
    {
        var userPermission = Helpers.Deserialize<FxPermissionUser>(GetPermissionUserFx);

        userPermission.UserRoles.First(
            UserRole => UserRole.RoleName == "Regional administrator"
            && UserRole.RoleTags == "regCANpgIRO").IsAssigned = true;

        userPermission.UserRoles.First(
            UserRole => UserRole.RoleName == "Regional administrator"
            && UserRole.RoleTags == "regAUSpgIRO").IsAssigned = true;

        userPermission.UserRoles.First(
            UserRole => UserRole.RoleName == "Global administrator"
            && UserRole.RoleTags == "regGLOBAL").IsAssigned = true;

        userPermission.IsGlobalAdmin = true;

        return userPermission;
    }
    public static FxPermissionUser GetAusGuestPermissionUser()
    {
        var userPermission = Helpers.Deserialize<FxPermissionUser>(GetPermissionUserFx);

        userPermission.UserRoles.First(
            UserRole => UserRole.RoleName == "Guest"
            && UserRole.RoleTags == "regAUSpgIRO").IsAssigned = true;

        return userPermission;
    }
    public static FxPermissionUser GetAusOfficerPermissionUser()
    {
        var userPermission = Helpers.Deserialize<FxPermissionUser>(GetPermissionUserFx);

        userPermission.UserRoles.First(
            UserRole => UserRole.RoleName == "Officer"
            && UserRole.RoleTags == "regAUSpgIRO").IsAssigned = true;

        return userPermission;
    }
    public static FxPermissionUser GetAusArrangerPermissionUser()
    {
        var userPermission = Helpers.Deserialize<FxPermissionUser>(GetPermissionUserFx);

        userPermission.UserRoles.First(
            UserRole => UserRole.RoleName == "Arranger"
            && UserRole.RoleTags == "regAUSpgIRO").IsAssigned = true;

        return userPermission;
    }
    public static FxPermissionUser GetAusRequestorPermissionUser()
    {
        var userPermission = Helpers.Deserialize<FxPermissionUser>(GetPermissionUserFx);

        userPermission.UserRoles.First(
            UserRole => UserRole.RoleName == "Requestor"
            && UserRole.RoleTags == "regAUSpgIRO").IsAssigned = true;

        return userPermission;
    }
    public static FxPermissionUser GetAusDemandOwnerPermissionUser()
    {
        var userPermission = Helpers.Deserialize<FxPermissionUser>(GetPermissionUserFx);

        userPermission.UserRoles.First(
            UserRole => UserRole.RoleName == "Demand owner"
            && UserRole.RoleTags == "regAUSpgIRO").IsAssigned = true;

        return userPermission;
    }

    public static FxPermissionUser GetAusSuspendedPermissionUser()
    {
        var userPermission = Helpers.Deserialize<FxPermissionUser>(GetPermissionUserFx);

        userPermission.UserRoles.First(
            UserRole => UserRole.RoleName == "Suspended"
            && UserRole.RoleTags == "regAUSpgIRO").IsAssigned = true;

        return userPermission;
    }
}
