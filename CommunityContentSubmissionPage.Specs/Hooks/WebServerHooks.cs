using CommunityContentSubmissionPage.Specs.Drivers;

namespace CommunityContentSubmissionPage.Specs.Hooks;

[Binding]
public class WebServerHooks
{
    #region Fields :
    private  readonly WebServerDriver _webServerDriver;
    #endregion
    
    #region CTORS :
    public WebServerHooks(WebServerDriver webServerDriver)
    {
        this._webServerDriver = webServerDriver;
    }
    #endregion

    #region Hooks :
    [BeforeScenario(Order =1000)]
    public void StartWebServer()
    {
        _webServerDriver.StartWebServer();
    }
    [AfterScenario]
    public  async Task StopWebServer()
    {
        await _webServerDriver.StopWebServer();
    } 
    #endregion
}
