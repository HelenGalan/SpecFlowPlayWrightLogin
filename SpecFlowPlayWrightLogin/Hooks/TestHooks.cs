using BoDi;
using SpecFlowPlayWrightLogin.PageObjects;
using TechTalk.SpecFlow;
using Microsoft.Playwright;

namespace SpecFlowPlayWrightLogin.Hooks
{
    [Binding]
    public sealed class TestHooks
    {
        [BeforeScenario("login")]
        public async Task BeforeFeatureLoginScenario(IObjectContainer container)
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 2000
            });
            
            container.RegisterInstanceAs(playwright);
            container.RegisterInstanceAs(browser);

            var page = await browser.NewPageAsync();
            container.RegisterInstanceAs(page);
            

            var pageObject = new LoginPageObject(browser, page);
            container.RegisterInstanceAs(pageObject);
        }



        [AfterScenario]
        public async Task AfterScenario(IObjectContainer container)
        {
            var browser = container.Resolve<IBrowser>();
            await browser.CloseAsync();
            var playwright = container.Resolve<IPlaywright>();
            playwright.Dispose();
        }
    }
}