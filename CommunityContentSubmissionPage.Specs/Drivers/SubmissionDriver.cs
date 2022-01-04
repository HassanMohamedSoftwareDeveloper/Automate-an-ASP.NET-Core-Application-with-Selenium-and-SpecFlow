using CommunityContentSubmissionPage.Business.Infrastructure;

namespace CommunityContentSubmissionPage.Specs.Drivers;

public class SubmissionDriver
{
    private readonly IDatabaseContext databaseContext;

    public SubmissionDriver(IDatabaseContext databaseContext)
    {
        this.databaseContext = databaseContext;
    }
    public void AssertNewSubmissionEntryExists()
    {
        databaseContext.SubmissionEntries.Count().Should().BeGreaterThan(0);
    }
}
