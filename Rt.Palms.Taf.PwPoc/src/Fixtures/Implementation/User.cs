using Rt.Palms.Taf.PwPoc.src.Fixtures.FxInterfaces;
using Rt.Palms.Taf.PwPoc.src.Support;
using Rt.Palms.Taf.PwPoc.src.Fixtures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rt.Palms.Taf.PwPoc.src.Fixtures.Implementation;

internal class User : IUser
{
    private static string GetUserFx => Helpers.ReadAllTextFromFile(Constants.userFixturePath);

    public static string GetAusRegionUserFixture => Helpers.Serialize(GetAusRegionUser());
    public static string GetCanRegionUserFixture => Helpers.Serialize(GetCanRegionUser());
    public static string GetBothAusAndCanRegionUserFixture => Helpers.Serialize(GetBothAusAndCanRegionUser());
    public static string GetGlobalAdminUserFixture => Helpers.Serialize(GetGlobalUser());
    public static FxUser GetAusRegionUser()
    {
        var user = Helpers.Deserialize<FxUser>(GetUserFx) ?? new FxUser();
        user.RegionTags = "regAUSpgIRO";
        return user;
    }

    public static FxUser GetCanRegionUser()
    {
        var user = Helpers.Deserialize<FxUser>(GetUserFx) ?? new FxUser();
        user.RegionTags = "regCANpgIRO";
        return user;
    }
    public static FxUser GetBothAusAndCanRegionUser()
    {
        var user = Helpers.Deserialize<FxUser>(GetUserFx) ?? new FxUser();
        user.RegionTags = "regCANpgIRO regAUSpgIRO";
        return user;
    }
    public static FxUser GetGlobalUser()
    {
        var user = Helpers.Deserialize<FxUser>(GetUserFx) ?? new FxUser();
        user.RegionTags = "regCANpgIRO regAUSpgIRO regGLOBAL";
        return user;
    }

}
