using Microsoft.Extensions.Hosting;

namespace CommunityContentSubmissionPage.Specs.Drivers;

public class WebServerDriver
{
    #region Fields :
    private IHost _host;
    #endregion
    #region PROPS :
    public string Hostname { get; private set; }
    #endregion
    #region Methods :
    public void StartWebServer()
    {
        Hostname = $"http://localhost:{GeneratePort()}";

        var hostBuilder = new KestrelHostBuilder();
        string location = typeof(KestrelHostBuilder)?.Assembly?.Location ?? throw new ArgumentNullException(nameof(location));
        string applicationAssemblyPath = Path.GetDirectoryName(location);
        string webRoot = Path.Combine(applicationAssemblyPath,
            "..", "..", "..", "..", "CommunityContentSubmissionPage", "wwwroot");
        var builder = hostBuilder.CreateHostBuilder(Array.Empty<string>(), Hostname, webRoot);

        _host = builder.Build();
        _host.StartAsync().ConfigureAwait(false);
    }
    public async Task StopWebServer()
    {
        if (_host is not null) await _host.StopAsync().ConfigureAwait(false);
    }
    #endregion
    #region Helpers :
    private static int GeneratePort() => new Random().Next(5000, 32000);  
    #endregion
}
