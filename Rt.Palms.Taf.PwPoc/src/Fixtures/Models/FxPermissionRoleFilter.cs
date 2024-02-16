using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rt.Palms.Taf.PwPoc.src.Fixtures.Models;

public partial class FxPermissionRoleFilter
{
    [JsonProperty("hierarchyId")]
    public Guid HierarchyId { get; set; }

    [JsonProperty("objectTypeId")]
    public object ObjectTypeId { get; set; }

    [JsonProperty("domain")]
    public string Domain { get; set; }

    [JsonProperty("page")]
    public string Page { get; set; }

    [JsonProperty("attributeName")]
    public string AttributeName { get; set; }

    [JsonProperty("attributeType")]
    public string AttributeType { get; set; }

    [JsonProperty("permissions")]
    public Permission[] Permissions { get; set; }
}

public partial class Permission
{
    [JsonProperty("key")]
    public string Key { get; set; }

    [JsonProperty("value")]
    public string Value { get; set; }
}