using CommunityContentSubmissionPage.Specs.Drivers;

namespace CommunityContentSubmissionPage.Specs.StepDefinitions;

[Binding]
public class WebPageStepDefinitions
{
    #region Fields :
    private readonly WebDriverDriver webDriverDriver;
    private readonly WebServerDriver webServerDriver;
    private readonly BrowserDriver browserDriver;
    #endregion

    #region CTORS :
    public WebPageStepDefinitions(WebDriverDriver webDriverDriver, WebServerDriver webServerDriver,BrowserDriver browserDriver)
    {
        this.webDriverDriver = webDriverDriver;
        this.webServerDriver = webServerDriver;
        this.browserDriver = browserDriver;
    }
    #endregion

    #region Steps :
    [When(@"the submission page is open")]
    public void WhenTheSubmissionpageIsOpen()
    {
        browserDriver.GoToUrl(webServerDriver.Hostname);
    }

    [Then(@"the title of the page is '([^']*)'")]
    public void ThenTheTitleOfThePageIs(string expectedPageTitle)
    {
        this.browserDriver.AssertTitle(expectedPageTitle);
    } 
    #endregion
}
