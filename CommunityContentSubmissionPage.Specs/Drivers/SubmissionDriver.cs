using CommunityContentSubmissionPage.Business.Infrastructure;
using CommunityContentSubmissionPage.Specs.StepDefinitions;

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
    public void AssertSubmissionEntryData(ExpectedSubmissionEntry expectedSubmissionEntry)
    {
        var actualEntry = databaseContext.SubmissionEntries.Single();
        actualEntry.ID.Should().Be(expectedSubmissionEntry.Id);
        if (actualEntry.Url is not null) actualEntry.Url.Should().Be(expectedSubmissionEntry.Url);
        if (actualEntry.Type is not null) actualEntry.Type.Should().Be(expectedSubmissionEntry.Type);
        if (actualEntry.EMail is not null) actualEntry.EMail.Should().Be(expectedSubmissionEntry.Email);
        if (actualEntry.Description is not null) actualEntry.Description.Should().Be(expectedSubmissionEntry.Description);
    }


}
