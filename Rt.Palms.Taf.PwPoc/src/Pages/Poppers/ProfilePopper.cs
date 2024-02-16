using Microsoft.Playwright;

namespace Rt.Palms.Taf.PwPoc.src.Pages.Poppers;

internal class ProfilePopper(IPage page)
{
    private readonly IPage _page = page;
    private ILocator ProfilePopperAvatar => _page.GetByTestId("appbar-profile-popper-avatar");
    private ILocator ProfilePopperName => _page.GetByTestId("appbar-profile-popper-name");
    private ILocator ProfilePopperEmail => _page.GetByTestId("appbar-profile-popper-business-email");
    private ILocator ProfilePopperViewAccount => _page.GetByTestId("appbar-profile-popper-view-account");
    private ILocator ProfilePopperSwitchView => _page.GetByTestId("appbar-profile-popper-switch-view");
    private ILocator ProfilePopperSignOut => _page.GetByTestId("appbar-profile-popper-sign-out");
    private ILocator ProfilePopperOrganisationalUnit => _page.GetByTestId("appbar-profile-popper-organisational-unit");

    public ILocator GetAvatar => ProfilePopperAvatar;
    public ILocator GetName => ProfilePopperName;
    public ILocator GetEmail => ProfilePopperEmail;
    public ILocator GetViewAccount => ProfilePopperViewAccount;
    public ILocator GetSwitchView => ProfilePopperSwitchView;
    public ILocator GetSignOut => ProfilePopperSignOut;
    public ILocator GetOrganisationalUnit => ProfilePopperOrganisationalUnit;

    public async Task<AdministratorPortalPage> ClickAdministration()
    {
        await GetSwitchView.ClickAsync();
        return new AdministratorPortalPage(_page);
    }
    public async Task<PalmsHomePage> ClickCustomer()
    {
        await GetSwitchView.ClickAsync();
        return new PalmsHomePage(_page);
    }

    public async Task ClickSignOut()
    {
        await GetSignOut.ClickAsync();
    }
}
