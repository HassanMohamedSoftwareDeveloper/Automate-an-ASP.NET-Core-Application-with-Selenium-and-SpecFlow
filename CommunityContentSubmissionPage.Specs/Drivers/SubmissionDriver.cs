using CommunityContentSubmissionPage.Business.Infrastructure;

namespace CommunityContentSubmissionPage.Specs.Drivers;

public class SubmissionDriver
{
    private readonly IDatabaseContext databaseContext;

    public SubmissionDriver(IDatabaseContext databaseContext)
    {
        this.databaseContext = databaseContext;
    }
    public void AssertOneSubmissionEntryExists()
    {
        databaseContext.SubmissionEntries.Count().Should().BeGreaterThan(0);
    }
    public void AssertNumberOfEntriesStored(int expectedCountOfStoredEntries)
    {
        databaseContext.SubmissionEntries.Count().Should().Be(expectedCountOfStoredEntries);

    }
}
