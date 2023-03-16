using _2_Services.Interfaces;
using _2_Services.Models;
using _2_Services.ServiceClasses;
using Microsoft.AspNetCore.Mvc;

namespace _1_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<UserModel>> Get()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<UserModel> Get(int id)
        {
            return await _service.GetById(id);
        }

        [HttpPost]
        public async Task<UserModel> post([FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            return await _service.Add(user);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            await _service.Update(user);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}
