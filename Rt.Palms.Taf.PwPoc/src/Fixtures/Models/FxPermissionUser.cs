using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rt.Palms.Taf.PwPoc.src.Fixtures.Models;


public partial class FxPermissionUser
{
    [JsonProperty("numberOfAdminRoles")]
    public NumberOfAdminRole[]? NumberOfAdminRoles { get; set; }

    [JsonProperty("userRoles")]
    public UserRole[]? UserRoles { get; set; }

    [JsonProperty("isGlobalAdmin")]
    public bool? IsGlobalAdmin { get; set; }
}

public partial class NumberOfAdminRole
{
    [JsonProperty("roleId")]
    public Guid RoleId { get; set; }

    [JsonProperty("count")]
    public long Count { get; set; }
}

public partial class UserRole
{
    [JsonProperty("userRoleId")]
    public Guid? UserRoleId { get; set; }

    [JsonProperty("roleId")]
    public Guid? RoleId { get; set; }

    [JsonProperty("sortOrder")]
    public long? SortOrder { get; set; }

    [JsonProperty("roleName")]
    public string? RoleName { get; set; }

    [JsonProperty("roleDescription")]
    public string? RoleDescription { get; set; }

    [JsonProperty("roleTags")]
    public string? RoleTags { get; set; }

    [JsonProperty("isRoleDefault")]
    public bool? IsRoleDefault { get; set; }

    [JsonProperty("isRoleAdmin")]
    public bool? IsRoleAdmin { get; set; }

    [JsonProperty("isAssigned")]
    public bool? IsAssigned { get; set; }


}

