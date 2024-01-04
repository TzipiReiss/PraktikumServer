using _3_Repository.Entities;
using _3_Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace _3_Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataSource data;
        public UserRepository(IDataSource _data)
        {
            data = _data;
        }

        public async Task<User> Add(User user)
        {
            _ = data.Users.AddAsync(user);
            await data.SaveChangesAsync();
            return user;
        }

        public async Task Delete(int id)
        {
            data.Users.Remove(await data.Users.FirstAsync(x => x.UserId == id));
            await data.SaveChangesAsync();
            data.Children.Where(x => x.UserId == id).ToList().ForEach(x => data.Children.Remove(x));
            await data.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            var users = await data.Users.ToListAsync();
            users.ForEach(u => u.Children = data.Children.Where(c => c.UserId == u.UserId).ToList());
            return users;
        }

        public async Task<User> GetById(int id)
        {
            return await data.Users.FindAsync(id);
        }

        public async Task Update(User user)
        {
            data.Users.Update(user);
            await data.SaveChangesAsync();
        }
    }
}
