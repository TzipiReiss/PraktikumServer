using _3_Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace _3_Repository.Interfaces
{
    public interface IDataSource
    {
        DbSet<User> Users { get; set; }
        DbSet<Child> Children { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}