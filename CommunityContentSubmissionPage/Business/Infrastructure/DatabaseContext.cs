using CommunityContentSubmissionPage.Business.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CommunityContentSubmissionPage.Business.Infrastructure;
public interface IDatabaseContext
{
    public DbSet<SubmissionEntry> SubmissionEntries { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken=default);
}
public class DatabaseContext : DbContext, IDatabaseContext
{
    public DbSet<SubmissionEntry> SubmissionEntries { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("CommunitySubmission");
    }
}
