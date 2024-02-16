using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rt.Palms.Taf.PwPoc.src.Fixtures.Models;

public partial class FxUserFind
{
    [JsonProperty("results")]
    public Result[]? Results { get; set; }

    [JsonProperty("count")]
    public long Count { get; set; }

    [JsonProperty("dataAggregatedFrom")]
    public long DataAggregatedFrom { get; set; }

    [JsonProperty("errorMessage")]
    public object? ErrorMessage { get; set; }
}

public partial class Result : FxUser
{
    //public FxUser[]? User { get; set; }
    //[JsonProperty("sourceSystem")]
    //public long SourceSystem { get; set; }

    //[JsonProperty("rank")]
    //public long Rank { get; set; }

    //[JsonProperty("levenshteinDistance")]
    //public long LevenshteinDistance { get; set; }

    //[JsonProperty("palmsUserGuid")]
    //public Guid PalmsUserGuid { get; set; }

    //[JsonProperty("hrInfoRequired")]
    //public bool HrInfoRequired { get; set; }

    //[JsonProperty("validated")]
    //public bool Validated { get; set; }

    //[JsonProperty("palmsRole")]
    //public string[] PalmsRole { get; set; }

    //[JsonProperty("palmsStatus")]
    //public string PalmsStatus { get; set; }

    //[JsonProperty("firstName")]
    //public string FirstName { get; set; }

    //[JsonProperty("lastName")]
    //public string LastName { get; set; }

    //[JsonProperty("middleName")]
    //public object MiddleName { get; set; }

    //[JsonProperty("preferredName")]
    //public string PreferredName { get; set; }

    //[JsonProperty("position")]
    //public string Position { get; set; }

    //[JsonProperty("personnelSubArea")]
    //public string PersonnelSubArea { get; set; }

    //[JsonProperty("sapPersonnelNumber")]
    //public long SapPersonnelNumber { get; set; }

    //[JsonProperty("sapPersonId")]
    //public long SapPersonId { get; set; }

    //[JsonProperty("dayOfBirth")]
    //public string DayOfBirth { get; set; }

    //[JsonProperty("dateOfBirth")]
    //public DateTimeOffset DateOfBirth { get; set; }

    //[JsonProperty("businessPhoneNumber")]
    //public object BusinessPhoneNumber { get; set; }

    //[JsonProperty("personalPhoneNumber")]
    //public string PersonalPhoneNumber { get; set; }

    //[JsonProperty("qantasFrequentFlyerNumber")]
    //public string QantasFrequentFlyerNumber { get; set; }

    //[JsonProperty("virginFrequentFlyerNumber")]
    //public string VirginFrequentFlyerNumber { get; set; }

    //[JsonProperty("leader")]
    //public string Leader { get; set; }

    //[JsonProperty("leaderId")]
    //public object LeaderId { get; set; }

    //[JsonProperty("leaderRole")]
    //public object LeaderRole { get; set; }

    //[JsonProperty("leaderRoleId")]
    //public long LeaderRoleId { get; set; }

    //[JsonProperty("contractorRepresentative")]
    //public object ContractorRepresentative { get; set; }

    //[JsonProperty("contractorRepresentativeId")]
    //public object ContractorRepresentativeId { get; set; }

    //[JsonProperty("contractorRepresentativeRole")]
    //public string ContractorRepresentativeRole { get; set; }

    //[JsonProperty("contractorRepresentativeRoleId")]
    //public object ContractorRepresentativeRoleId { get; set; }

    //[JsonProperty("organisationalUnit")]
    //public string OrganisationalUnit { get; set; }

    //[JsonProperty("organisationalUnitId")]
    //public long OrganisationalUnitId { get; set; }

    //[JsonProperty("personnelArea")]
    //public string PersonnelArea { get; set; }

    //[JsonProperty("personnelAreaId")]
    //public string PersonnelAreaId { get; set; }

    //[JsonProperty("businessUnit")]
    //public object BusinessUnit { get; set; }

    //[JsonProperty("businessUnitId")]
    //public object BusinessUnitId { get; set; }

    //[JsonProperty("employer")]
    //public string Employer { get; set; }

    //[JsonProperty("employerId")]
    //public string EmployerId { get; set; }

    //[JsonProperty("costCentre")]
    //public string CostCentre { get; set; }

    //[JsonProperty("costCentreId")]
    //public string CostCentreId { get; set; }

    //[JsonProperty("workSchedule")]
    //public object WorkSchedule { get; set; }

    //[JsonProperty("workScheduleId")]
    //public object WorkScheduleId { get; set; }

    //[JsonProperty("employmentClass")]
    //public string EmploymentClass { get; set; }

    //[JsonProperty("reservation")]
    //public string Reservation { get; set; }

    //[JsonProperty("homePort")]
    //public string HomePort { get; set; }

    //[JsonProperty("originPort")]
    //public string OriginPort { get; set; }

    //[JsonProperty("workPort")]
    //public string WorkPort { get; set; }

    //[JsonProperty("palmsCostCode")]
    //public string PalmsCostCode { get; set; }

    //[JsonProperty("palmsCostCodeId")]
    //public object PalmsCostCodeId { get; set; }
}