using _3_Repository.Entities;
using _3_Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Repository.Repositories
{
    public class ChildRepository : IChildRepository
    {
        private readonly IDataSource data;
        public ChildRepository(IDataSource _data)
        {
            data = _data;
        }

         public async Task<Child> Add(Child child)
        {
            EntityEntry<Child> newChild = await data.Children.AddAsync(child);
            await data.SaveChangesAsync();
            return newChild.Entity;
        }

        public async Task Delete(int id)
        {
            data.Children.Remove(await GetById(id));
            await data.SaveChangesAsync();
        }

        public async Task<List<Child>> GetAll()
        {
            return await data.Children.ToListAsync();
        }

        public async Task<Child> GetById(int id)
        {
            return await data.Children.FindAsync(id);
        }

        public async Task Update(Child Child)
        {
            data.Children.Update(Child);
            await data.SaveChangesAsync();
        }
    }
}
