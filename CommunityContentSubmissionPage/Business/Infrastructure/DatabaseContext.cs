using CommunityContentSubmissionPage.Business.Model;
using Microsoft.EntityFrameworkCore;

namespace CommunityContentSubmissionPage.Business.Infrastructure;
public interface IDatabaseContext
{
    public DbSet<SubmissionEntry> SubmissionEntries { get; set; }
    int SaveChanges();
}
public class DatabaseContext : DbContext, IDatabaseContext
{
    public DbSet<SubmissionEntry> SubmissionEntries { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("CommunitySubmission");
    }
}
