namespace CommunityContentSubmissionPage.Specs.Drivers;

public class BrowserDriver
{
    #region Fields :
    private readonly WebDriverDriver webDriverDriver;
    #endregion

    #region CTORS :
    public BrowserDriver(WebDriverDriver webDriverDriver)
    {
        this.webDriverDriver = webDriverDriver;
    }
    #endregion

    #region PROPS :
    public string Title => webDriverDriver.WebDriver.Title;
    public string Url => webDriverDriver.WebDriver.Url;
    #endregion

    #region Methods :
    public void AssertTitle(string expectedTitle)
    {
        this.Title.Should().Be(expectedTitle); 
    }

    public void GoToUrl(string hostname)
    {
        this.webDriverDriver.WebDriver.Url = hostname;
    }
    #endregion
}
