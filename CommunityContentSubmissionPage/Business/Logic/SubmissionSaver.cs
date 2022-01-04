using CommunityContentSubmissionPage.Business.Infrastructure;
using CommunityContentSubmissionPage.Business.Model;

namespace CommunityContentSubmissionPage.Business.Logic;
 
public interface ISubmissionSaver
{
    void Save(SubmissionEntry submission);
}
public class SubmissionSaver:ISubmissionSaver
{
    private readonly IDatabaseContext databaseContext;

    public SubmissionSaver(IDatabaseContext databaseContext)
    {
        this.databaseContext = databaseContext;
    }
    public void Save(SubmissionEntry submission)
    {
        databaseContext.SubmissionEntries.Add(submission);
        databaseContext.SaveChanges();
    }
}
