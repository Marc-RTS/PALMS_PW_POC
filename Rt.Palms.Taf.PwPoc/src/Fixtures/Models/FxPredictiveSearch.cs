using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rt.Palms.Taf.PwPoc.src.Fixtures.Models;

public partial class FxPredictiveSearch
{
    [JsonProperty("palmsUserGuids")]
    public Guid[] PalmsUserGuids { get; set; }

    [JsonProperty("firstName")]
    public string FirstName { get; set; }

    [JsonProperty("lastName")]
    public string LastName { get; set; }

    [JsonProperty("preferredName")]
    public string PreferredName { get; set; }
}

