using Newtonsoft.Json;

namespace Rt.Palms.Taf.PwPoc.src.Support;

public class Helpers
{
    public static String Serialize<T>(T value)
    {
        var valueJson = JsonConvert.SerializeObject(value);
        return valueJson;
    }

    public static T? Deserialize<T>(string fixture)
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(fixture);
        }
        catch (Exception ex)
        {

            return default;
        }
    }

    public static string ReadAllTextFromFile(string filePath)
    {
        return File.ReadAllText(filePath);
    }
}
