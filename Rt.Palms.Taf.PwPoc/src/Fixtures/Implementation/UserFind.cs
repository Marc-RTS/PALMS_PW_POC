using Rt.Palms.Taf.PwPoc.src.Support;
using Rt.Palms.Taf.PwPoc.src.Fixtures.Models;


namespace Rt.Palms.Taf.PwPoc.src.Fixtures.Implementation;

internal class UserFind
{
    private static string GetUserFindFx => Helpers.ReadAllTextFromFile(Constants.userFindFixturePath);

    public static FxUserFind GetDefaultUserFind => Helpers.Deserialize<FxUserFind>(GetUserFindFx) ?? new FxUserFind();
    private static FxUserFind GetUserFindNoProfileFound()
    {
        var userFindNoProfile = Helpers.Deserialize<FxUserFind>(GetUserFindFx);
        userFindNoProfile.Results = [];
        userFindNoProfile.Count = 0;
        userFindNoProfile.DataAggregatedFrom = 1;
        userFindNoProfile.ErrorMessage = null;
        return userFindNoProfile;
    }
    public static string GetDefaultUserFindFixture => Helpers.Serialize(GetDefaultUserFind);
    public static string GetUserFindNoProfileFoundFixture => Helpers.Serialize(GetUserFindNoProfileFound());
}
