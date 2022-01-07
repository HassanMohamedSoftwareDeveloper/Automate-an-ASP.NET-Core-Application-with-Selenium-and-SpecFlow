using CommunityContentSubmissionPage.Business.Infrastructure;

namespace CommunityContentSubmissionPage.Specs.Hooks;
[Binding]
public class DIConfiguration
{
    private readonly ScenarioContext scenarioContext;

    public DIConfiguration(ScenarioContext scenarioContext)
    {
        this.scenarioContext = scenarioContext;
    }
    [BeforeScenario(Order =0)]
    public void Register()
    {
        scenarioContext.ScenarioContainer.RegisterTypeAs<DatabaseContext,IDatabaseContext>(); 
    }
    [AfterScenario]
    public void CleanUp()
    {
        DatabaseContext dataContext = scenarioContext.ScenarioContainer.Resolve<DatabaseContext>();
        dataContext.Database.EnsureDeleted();
    }
}
