using _3_Repository.Entities;
using _3_Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task Add(User user)
        {
            var u = data.Users.AddAsync(user);
            await data.SaveChangesAsync();
            foreach (var item in user.Children)
            {
                item.UserId=user.UserId;
                data.Children.Add(item);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            data.Users.Remove(await data.Users.FirstAsync(x => x.UserId == id));
            data.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return await data.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await data.Users.FindAsync(id);
        }

        public async Task Update(User user)
        {
            data.Users.Update(user);
            data.SaveChangesAsync();
        }
    }
}
