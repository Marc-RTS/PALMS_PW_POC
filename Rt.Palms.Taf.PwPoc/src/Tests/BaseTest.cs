using Microsoft.Playwright;
using NUnit.Allure.Core;
using Rt.Palms.Taf.PwPoc.src.Pages;


namespace Rt.Palms.Taf.PwPoc.src.Tests;

public class BaseTest
{

    public static string BrowserName => Microsoft.Playwright.BrowserType.Chromium; //TODO: source from run-settings/appsettings
    private static readonly Task<IPlaywright> playwrightTask = Microsoft.Playwright.Playwright.CreateAsync();
    public IPlaywright Playwright { get; private set; }
    public IBrowserType BrowserType { get; private set; }
    public IBrowser Browser { get; internal set; }
    public IBrowserContext Context { get; private set; }
    public ITracing Tracing { get; private set; }
    public IPage Page { get; private set; }

    [OneTimeSetUp]
    public async Task PALMSSetup()
    {
        Playwright = await playwrightTask.ConfigureAwait(false);
        BrowserType = Playwright[BrowserName];
        Browser = await BrowserType.LaunchAsync(new()
        {
            Headless = false //TODO: source from run-settings/appsettings
        });

        // One-time login to capture token
        Context = await Browser.NewContextAsync(
            new BrowserNewContextOptions
            {
                JavaScriptEnabled = true,
                ViewportSize = new ViewportSize() { Width = 1920, Height = 1080 }
            });
        Page = await Context.NewPageAsync();
        var loginPage = new LoginPage(Page);
        var palmsHomePage = new PalmsHomePage(Page);
        await loginPage.OpenUrl();
        await loginPage.Login("w3lcomet0palms");  //TODO: source from run-settings/appsettingss
        await Expect(palmsHomePage.GetPageHeader).ToContainTextAsync(Constants.HomePageHeader);
        await Expect(palmsHomePage.GetBanner).ToContainTextAsync(Constants.PageBanner);

        //TO DO assert storage?
        await Page.Context.StorageStateAsync(new BrowserContextStorageStateOptions { Path = Constants.adminAuth });
        await Page.CloseAsync();
    }

    [OneTimeTearDown]
    public async Task BrowserTearDown()
    {
        await Context.CloseAsync(); //.ConfigureAwait(false);
        Browser = null;
    }
    [SetUp]
    public async Task SetupEachTest()
    {
        Context = await Browser.NewContextAsync(
          new BrowserNewContextOptions
          {
              StorageStatePath = Constants.adminAuth,
              JavaScriptEnabled = true,
              ViewportSize = new ViewportSize() { Width = 1920, Height = 1080 }
          });

        await Context.Tracing.StartAsync(new()
        {
            Title = TestContext.CurrentContext.Test.ClassName + "." + TestContext.CurrentContext.Test.Name,
            Screenshots = bool.Parse(TestContext.Parameters["screenshot"] ?? "false"),
            Snapshots = bool.Parse(TestContext.Parameters["snapshots"] ?? "false"),
            Sources = bool.Parse(TestContext.Parameters["sources"] ?? "false")
        });
        Page = await Context.NewPageAsync();
    }

    [TearDown]
    public async Task TearDown()
    {
        await Context.Tracing.StopAsync(new()
        {
            Path = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                TestContext.Parameters["traces"],
                $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
            )
        });
    }

    //public async Task<IBrowserContext> NewContext(BrowserNewContextOptions options)
    //{
    //    return await Browser.NewContextAsync(options).ConfigureAwait(false);
    //}

    public ILocatorAssertions Expect(ILocator locator) => Assertions.Expect(locator);

    public IPageAssertions Expect(IPage page) => Assertions.Expect(page);
}
