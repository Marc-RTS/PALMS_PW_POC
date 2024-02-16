using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Rt.Palms.Taf.PwPoc.src.Fixtures.Models;


public partial class FxRbac
{
    [JsonProperty("hierarchyObjectsWithStatus")]
    public HierarchyObjectsWithStatus[]? HierarchyObjectsWithStatus { get; set; }

    [JsonProperty("regions")]
    public string[]? Regions { get; set; }
}

public partial class HierarchyObjectsWithStatus
{
    [JsonProperty("hierarchyId")]
    public Guid? HierarchyId { get; set; }

    [JsonProperty("status")]
    public string? Status { get; set; }

    [JsonProperty("hierarchyName")]
    public string? HierarchyName { get; set; }

    [JsonProperty("pageName")]
    public string? PageName { get; set; }

    [JsonProperty("objectType")]
    public string? ObjectType { get; set; }
}


