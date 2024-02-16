using Rt.Palms.Taf.PwPoc.src.Fixtures.Models;
using Rt.Palms.Taf.PwPoc.src.Support;

namespace Rt.Palms.Taf.PwPoc.src.Fixtures.Implementation;

internal class PredictiveSearch
{
    private static string GetDefaultPredictiveSearchFx => Helpers.ReadAllTextFromFile(Constants.predictiveSearchFixturePath);

    public static FxPredictiveSearch[] GetDefaultUserFindPredictiveSearch() {
        return Helpers.Deserialize<FxPredictiveSearch[]>(GetDefaultPredictiveSearchFx) ?? [];
    }

    public static string GetDefaultUserFindPredictiveSearchFixture => Helpers.Serialize(GetDefaultUserFindPredictiveSearch());
    
}
