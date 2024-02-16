using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace Rt.Palms.Taf.PwPoc.src.Pages;

public class LoginPage(IPage page)
{
    private readonly IPage _page = page;
    private ILocator BtnLogin => _page.GetByTestId("login-login-button");
    private ILocator TxtBoxpassword => _page.GetByTestId("login-password-input-inner");
    private ILocator PalmsLogo => _page.Locator("");
    private ILocator PalmsTitle => _page.Locator("");

    public async Task ClickLogin() => await BtnLogin.ClickAsync();

    public async Task InputPassword(string password)
    {
        await TxtBoxpassword.ClickAsync();
        await TxtBoxpassword.FillAsync(password);
    }

    public async Task Login(string password)
    {
        await InputPassword(password);
        await ClickLogin();
    }

    public async Task OpenUrl()
    {
        await _page.GotoAsync(TestContext.Parameters["webUrl"]);
    }

}
