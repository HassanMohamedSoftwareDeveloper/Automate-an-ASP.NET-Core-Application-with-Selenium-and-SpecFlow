using CommunityContentSubmissionPage.Business.Infrastructure;
using CommunityContentSubmissionPage.Business.Model;

namespace CommunityContentSubmissionPage.Business.Logic;
 
public interface ISubmissionSaver
{
    Task Save(SubmissionEntry submission);
}
public class SubmissionSaver:ISubmissionSaver
{
    private readonly IDatabaseContext databaseContext;

    public SubmissionSaver(IDatabaseContext databaseContext)
    {
        this.databaseContext = databaseContext;
    }
    public async Task Save(SubmissionEntry submission)
    {
        await databaseContext.SubmissionEntries.AddAsync(submission);
        await databaseContext.SaveChangesAsync();
    }
}
