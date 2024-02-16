using Rt.Palms.Taf.PwPoc.src.Support;
using Rt.Palms.Taf.PwPoc.src.Fixtures.Models;

namespace Rt.Palms.Taf.PwPoc.src.Fixtures.Implementation;

internal class Rbac
{
    private static string GetRbacFx => Helpers.ReadAllTextFromFile(Constants.rbacFixturePath);
    public static string GetGlobalAdminRbacFixture => Helpers.Serialize(GetGlobalAdminRbac());
    public static string GetBothAusAndCanRegionalAdminRbacFixture => Helpers.Serialize(GetBothAusAndCanRegionalAdminRbac());
    public static string GetCanRegionalAdminRbacFixture => Helpers.Serialize(GetCanRegionalAdminRbac());
    public static string GetAusRegionalAdminRbacFixture => Helpers.Serialize(GetAusRegionalAdminRbac());
    public static string GetRbacNoRegionsFixture => Helpers.Serialize(GetRbacNoRegionsRbac());

    public static FxRbac GetAusRegionalAdminRbac()
    {
        var rbac = Helpers.Deserialize<FxRbac>(GetRbacFx) ?? new FxRbac();
        rbac.Regions = ["regAUSpgIRO"];
        return rbac;
    }

    public static FxRbac GetCanRegionalAdminRbac()
    {
        var rbac = Helpers.Deserialize<FxRbac>(GetRbacFx) ?? new FxRbac();
        rbac.Regions = ["regCANpgIRO"];
        return rbac;
    }

    public static FxRbac GetBothAusAndCanRegionalAdminRbac()
    {
        var rbac = Helpers.Deserialize<FxRbac>(GetRbacFx) ?? new FxRbac();
        rbac.Regions = ["regCANpgIRO", "regAUSpgIRO"];
        return rbac;
    }

    public static FxRbac GetGlobalAdminRbac()
    {
        var rbac = Helpers.Deserialize<FxRbac>(GetRbacFx) ?? new FxRbac();
        rbac.Regions = ["regAUSpgIRO", "regCANpgIRO", "regGLOBAL"];
        return rbac;
    }
    public static FxRbac GetRbacNoRegionsRbac()
    {
        var rbac = Helpers.Deserialize<FxRbac>(GetRbacFx) ?? new FxRbac();
        rbac.Regions = [];
        return rbac;
    }
}
