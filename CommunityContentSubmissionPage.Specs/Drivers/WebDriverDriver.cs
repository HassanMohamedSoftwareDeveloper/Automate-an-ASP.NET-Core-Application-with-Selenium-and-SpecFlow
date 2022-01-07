using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CommunityContentSubmissionPage.Specs.Drivers;

public class WebDriverDriver:IDisposable
{
    #region Fields :
    private readonly Lazy<IWebDriver> webDriver;
    #endregion
    #region PROPS :
    public IWebDriver WebDriver => webDriver.Value;
    #endregion
    #region CTORS :
    public WebDriverDriver()
    {
        webDriver = new(() => CreateWebDriver());
    }
    #endregion
    #region Methods :
    public void Dispose()
    {
        webDriver.Value.Quit();
    }
    #endregion
    #region Helpers :
    private static IWebDriver CreateWebDriver() => new ChromeDriver();
    #endregion
}
