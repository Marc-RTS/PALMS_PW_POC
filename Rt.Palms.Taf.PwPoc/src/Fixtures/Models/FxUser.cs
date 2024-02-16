using System;
using Newtonsoft.Json;

namespace Rt.Palms.Taf.PwPoc.src.Fixtures.Models;

public partial class FxUser
{
    [JsonProperty("sourceSystem")]
    public long? SourceSystem { get; set; }

    [JsonProperty("rank")]
    public long? Rank { get; set; }

    [JsonProperty("palmsUserGuid")]
    public Guid? PalmsUserGuid { get; set; }

    [JsonProperty("hrInfoRequired")]
    public bool? HrInfoRequired { get; set; }

    [JsonProperty("validated")]
    public bool? Validated { get; set; }

    [JsonProperty("palmsStatus")]
    public string? PalmsStatus { get; set; }

    [JsonProperty("sapStatus")]
    public long? SapStatus { get; set; }

    [JsonProperty("firstName")]
    public string? FirstName { get; set; }

    [JsonProperty("lastName")]
    public string? LastName { get; set; }

    [JsonProperty("middleName")]
    public object? MiddleName { get; set; }

    [JsonProperty("preferredName")]
    public string? PreferredName { get; set; }

    [JsonProperty("position")]
    public string? Position { get; set; }

    [JsonProperty("positionId")]
    public long? PositionId { get; set; }

    [JsonProperty("sapPersonnelNumber")]
    public long? SapPersonnelNumber { get; set; }

    [JsonProperty("sapPersonId")]
    public long? SapPersonId { get; set; }

    [JsonProperty("salutation")]
    public string? Salutation { get; set; }

    [JsonProperty("sexAssignedAtBirth")]
    public string? SexAssignedAtBirth { get; set; }

    [JsonProperty("homePostcode")]
    public string? HomePostcode { get; set; }

    [JsonProperty("genderIdentity")]
    public string? GenderIdentity { get; set; }

    [JsonProperty("regionTags")]
    public string? RegionTags { get; set; }

    [JsonProperty("dayOfBirth")]
    public string? DayOfBirth { get; set; }

    [JsonProperty("dateOfBirth")]
    public object? DateOfBirth { get; set; }

    [JsonProperty("businessMobileNumber")]
    public object? BusinessMobileNumber { get; set; }

    [JsonProperty("personalMobileNumber")]
    public string? PersonalMobileNumber { get; set; }

    [JsonProperty("businessLandLineNumber")]
    public object? BusinessLandLineNumber { get; set; }

    [JsonProperty("businessEmailAddress")]
    public object? BusinessEmailAddress { get; set; }

    [JsonProperty("personalEmailAddress")]
    public string? PersonalEmailAddress { get; set; }

    [JsonProperty("qantasFrequentFlyerNumber")]
    public long? QantasFrequentFlyerNumber { get; set; }

    [JsonProperty("virginFrequentFlyerNumber")]
    public string? VirginFrequentFlyerNumber { get; set; }

    [JsonProperty("leader")]
    public string? Leader { get; set; }

    [JsonProperty("leaderId")]
    public long? LeaderId { get; set; }

    [JsonProperty("leaderRole")]
    public string? LeaderRole { get; set; }

    [JsonProperty("leaderRoleId")]
    public object? LeaderRoleId { get; set; }

    [JsonProperty("contractorRepresentative")]
    public object? ContractorRepresentative { get; set; }

    [JsonProperty("contractorRepresentativeId")]
    public object? ContractorRepresentativeId { get; set; }

    [JsonProperty("contractorRepresentativeRole")]
    public string? ContractorRepresentativeRole { get; set; }

    [JsonProperty("contractorRepresentativeRoleId")]
    public object? ContractorRepresentativeRoleId { get; set; }

    [JsonProperty("organisationalUnit")]
    public string? OrganisationalUnit { get; set; }

    [JsonProperty("organisationalUnitId")]
    public long? OrganisationalUnitId { get; set; }

    [JsonProperty("businessUnit")]
    public object? BusinessUnit { get; set; }

    [JsonProperty("businessUnitId")]
    public object? BusinessUnitId { get; set; }

    [JsonProperty("personnelArea")]
    public string? PersonnelArea { get; set; }

    [JsonProperty("personnelAreaId")]
    public string? PersonnelAreaId { get; set; }

    [JsonProperty("personnelSubArea")]
    public string? PersonnelSubArea { get; set; }

    [JsonProperty("personnelSubAreaId")]
    public string? PersonnelSubAreaId { get; set; }

    [JsonProperty("employer")]
    public string? Employer { get; set; }

    [JsonProperty("employerId")]
    public string? EmployerId { get; set; }

    [JsonProperty("costCentre")]
    public string? CostCentre { get; set; }

    [JsonProperty("costCentreId")]
    public string? CostCentreId { get; set; }

    [JsonProperty("palmsCostCode")]
    public string? PalmsCostCode { get; set; }

    [JsonProperty("palmsCostCodeId")]
    public object? PalmsCostCodeId { get; set; }

    [JsonProperty("palmsCostCodeStartDate")]
    public object? PalmsCostCodeStartDate { get; set; }

    [JsonProperty("palmsCostCodeEndDate")]
    public object? PalmsCostCodeEndDate { get; set; }

    [JsonProperty("workSchedule")]
    public object? WorkSchedule { get; set; }

    [JsonProperty("workScheduleId")]
    public object? WorkScheduleId { get; set; }

    [JsonProperty("employmentClass")]
    public string? EmploymentClass { get; set; }

    [JsonProperty("currency")]
    public object? Currency { get; set; }

    [JsonProperty("country")]
    public object? Country { get; set; }

    [JsonProperty("assignmentStartDate")]
    public object? AssignmentStartDate { get; set; }

    [JsonProperty("assignmentEndDate")]
    public object? AssignmentEndDate { get; set; }

    [JsonProperty("reservation")]
    public string? Reservation { get; set; }

    [JsonProperty("homePort")]
    public string? HomePort { get; set; }

    [JsonProperty("originPort")]
    public string? OriginPort { get; set; }

    [JsonProperty("workPort")]
    public string? WorkPort { get; set; }
}