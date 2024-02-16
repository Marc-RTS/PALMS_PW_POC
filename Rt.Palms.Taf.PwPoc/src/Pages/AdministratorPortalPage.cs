using Microsoft.Playwright;
using Rt.Palms.Taf.PwPoc.src.Pages.SideBars;

namespace Rt.Palms.Taf.PwPoc.src.Pages;

internal class AdministratorPortalPage(IPage page)
{
    private readonly IPage _page = page;
    private RouteListSidebar _routeList = new(page);
    private ILocator AdministratorPortalPageHeader => _page.GetByRole(AriaRole.Heading);
    private ILocator AdministratorPortalPageTitle => _page.GetByTestId("appbar-title");
    private ILocator RegionSelector => _page.GetByTestId("appbar-region");
    private ILocator RegionCanIronOre => _page.GetByTestId("appbar-region-select-regCANpgIRO");
    private ILocator RegionAusIronOre => _page.GetByTestId("appbar-region-select-regAUSpgIRO");
    private ILocator RegionGlobal => _page.GetByTestId("appbar-region-select-regGLOBAL");
    private ILocator ArrowDropDownIcon => _page.GetByTestId("ArrowDropDownIcon");
    
    public ILocator GetAdministratorPortalPageHeader => AdministratorPortalPageHeader;
    public ILocator GetAdministratorPortalPageTitle => AdministratorPortalPageTitle;
    public ILocator GetRegionSelector => RegionSelector;
    public ILocator GetRegionAusIronOre => RegionAusIronOre;
    public ILocator GetRegionCanIronOre => RegionCanIronOre;
    public ILocator GetRegionGlobal => RegionGlobal;
    public ILocator GetArrowDropDownIcon => ArrowDropDownIcon;

    public async Task ClickRegionSelector()
    {
        await GetRegionSelector.ClickAsync();
    }

    public async Task ClickArrowDropDownIcon()
    {
        await GetArrowDropDownIcon.ClickAsync();
    }

    public async Task SelectAusIronOreRegion()
    {
        await GetRegionAusIronOre.ClickAsync();
    }

    public async Task SelectCanIronOreRegion()
    {
        await GetRegionCanIronOre.ClickAsync();
    }

    public async Task SelectGlobalRegion()
    {
        await GetRegionGlobal.ClickAsync();
    }

    public async Task SwitchToAusIronOreRegion()
    {
        await ClickRegionSelector();
        await SelectAusIronOreRegion();
    }

    public async Task SwitchToCanIronOreRegion()
    {
        await ClickRegionSelector();
        await SelectCanIronOreRegion();
    }

    public async Task SwitchToGlobalRegion()
    {
        await ClickRegionSelector();
        await SelectGlobalRegion();
    }
}
