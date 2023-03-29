using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace SpecFlowPlayWrightLogin.PageObjects
{
    public class LoginPageObject : BasePageObject
    {       
        public override string PagePath => "https://www.google.com/";

        public LoginPageObject(IBrowser browser, IPage page)
        {
            Browser = browser;
            Page = page;
        }

        public override IPage Page { get; set; }
        public override IBrowser Browser { get; }

        public async Task ApprovePolicyAsync()
        {
            await Page.WaitForSelectorAsync("#L2AGLb", new PageWaitForSelectorOptions { State = WaitForSelectorState.Attached });
            await Task.Delay(1000);
            await Page.ClickAsync("#L2AGLb");
        }

        public Task FillInSearchField(string subject) => Page.FillAsync("body > div.L3eUgb > div.o3j99.ikrT4e.om7nvf > form > div:nth-child(1) > div.A8SBwf > div.RNNXgb > div > div.a4bIc > input", subject);

        public async Task ClickOnSearchAsync()
        {
            await Page.Keyboard.PressAsync("Enter");
        }

        public async Task ClickOnSpecFlowLink()
        {
            await Page.ClickAsync("a[href='https://specflow.org/']", new PageClickOptions
            {
                Timeout = 60000
            });

        }


    }
}
