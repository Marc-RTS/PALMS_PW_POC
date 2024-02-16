using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rt.Palms.Taf.PwPoc.src.Pages.SideBars;

internal class ProfileSidebar(IPage page)
{
    private readonly IPage _page = page;
    private ILocator Name => _page.GetByTestId("search-sidebar-name");
    private ILocator Position => _page.GetByTestId("search-sidebar-position");
    private ILocator MobileNumber => _page.GetByTestId("search-sidebar-personal-mobile-value");
    private ILocator PersonnelNumber => _page.GetByTestId("search-sidebar-personnel-number-value");
    private ILocator QantasFrequentFlyer => _page.GetByTestId("search-sidebar-qantas-frequent-flyer-value");
    private ILocator VirginFrequentFlyer => _page.GetByTestId("search-sidebar-virgin-frequent-flyer-value");
    private ILocator LeaderName => _page.GetByTestId("search-sidebar-leader-name-label");
    private ILocator LeaderPersonnelNumber => _page.GetByTestId("search-sidebar-leader-name-value");
    private ILocator LeaderRole => _page.GetByTestId("search-sidebar-leader-role-label");
    private ILocator OrgUnitName => _page.GetByTestId("search-sidebar-org-unit-subtitle");
    private ILocator OrgUnitId => _page.GetByTestId("search-sidebar-org-unit-value");
    private ILocator PersonnelArea => _page.GetByTestId("search-sidebar-personnel-area-subtitle");
    private ILocator PersonnelAreaId => _page.GetByTestId("search-sidebar-personnel-area-value");
    private ILocator Employer => _page.GetByTestId("search-sidebar-employer-subtitle");
    private ILocator EmployerId => _page.GetByTestId("search-sidebar-employer-value");
    private ILocator CostCode => _page.GetByTestId("search-sidebar-cost-code-subtitle");
    private ILocator Employment => _page.GetByTestId("search-sidebar-employment-value");

    public ILocator GetName => Name;
    public ILocator GetPosition => Position;
    public ILocator GetMobileNumber => MobileNumber;
    public ILocator GetPersonnelNumber => PersonnelNumber;
    public ILocator GetQantasFrequentFlyer => QantasFrequentFlyer;
    public ILocator GetVirginFrequentFlyer => VirginFrequentFlyer;
    public ILocator GetLeaderName => LeaderName;
    public ILocator GetLeaderPersonnelNumber => LeaderPersonnelNumber;
    public ILocator GetLeaderRole => LeaderRole;
    public ILocator GetOrgUnitName => OrgUnitName;
    public ILocator GetOrgUnitId => OrgUnitId;
    public ILocator GetPersonnelArea => PersonnelArea;
    public ILocator GetPersonnelAreaId => PersonnelAreaId;
    public ILocator GetEmployer => Employer;
    public ILocator GetEmployerId => EmployerId;
    public ILocator GetCostCode => CostCode;
    public ILocator GetEmployment => Employment;
}
