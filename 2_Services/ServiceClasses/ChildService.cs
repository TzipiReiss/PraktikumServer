using _2_Services.Interfaces;
using _2_Services.Models;
using _3_Repository.Entities;
using _3_Repository.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Services.ServiceClasses
{
    public class ChildService : IChildService
    {
        private readonly IChildRepository rep;
        private readonly IMapper mapper;
        public ChildService(IChildRepository rep, IMapper mapper)
        {
            this.rep = rep;
            this.mapper = mapper;
        }

         public async Task<ChildModel> Add(ChildModel child)
        {
            return mapper.Map<ChildModel>(await rep.Add(mapper.Map<Child>(child)));
        }

        public async Task Delete(int id)
        {
            await rep.Delete(id);
        }

        public async Task<IEnumerable<ChildModel>> GetAll()
        {
            return mapper.Map<List<ChildModel>>(await rep.GetAll());
        }

        public async Task<ChildModel> GetById(int id)
        {
            return mapper.Map<ChildModel>(await rep.GetById(id));
        }

        public async Task Update(ChildModel child)
        {
            await rep.Update(mapper.Map<Child>(child));
        }
    }
}
