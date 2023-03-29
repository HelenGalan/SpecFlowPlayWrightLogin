using SpecFlowPlayWrightLogin.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace SpecFlowPlayWrightLogin.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly LoginPageObject _pageObject;

        public LoginStepDefinitions(LoginPageObject pageObject)
        {
            _pageObject = pageObject;
        }

        [Given(@"the user is on google")]
        public async Task GivenTheUserIsOnGoogle()
        {
            await _pageObject.NavigateAsync();
        }

        [Given(@"approve Google privacy policy")]
        public async Task GivenApproveGooglePrivacyPolicy()
        {
            await _pageObject.ApprovePolicyAsync();
        }


        [Given(@"he types in SpecFlow into the search field")]
        public async Task GivenHeTypesInSpecFlowIntoTheSearchField()
        {
            await _pageObject.FillInSearchField("SpecFlow");
        }

        [When(@"he clicks search the official site appears")]
        public async Task WhenHeClicksSearchTheOfficialSiteAppears()
        {
            await _pageObject.ClickOnSearchAsync();
        }

        [Then(@"he clicks on the link and goes to '(.*)'")]
        public async Task ThenHeClicksOnTheLinkAndGoesTo(string targetUrl)
        {
            await _pageObject.ClickOnSpecFlowLink();
            _pageObject.Page.Url.Should().Be(targetUrl);
        }
    }

}

