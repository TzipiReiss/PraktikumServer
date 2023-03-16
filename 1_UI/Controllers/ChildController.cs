using _2_Services.Interfaces;
using _2_Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        IChildService _service;
        IUserService _userService;
        public ChildController(IChildService service, IUserService userService)
        {
            _service = service;
            _userService = userService; 
        }

        [HttpGet]
        public async Task<IEnumerable<ChildModel>> Get()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ChildModel> Get(int id)
        {
            return await _service.GetById(id);
        }

        [HttpPost]
        public async Task<ChildModel> post([FromBody] ChildModel child)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            var c = await _service.Add(child);
            UserModel u = _userService.GetById((int)child.UserId).Result;
            u.Children.Add(child);
            return c;
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] ChildModel child)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            await _service.Update(child);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}
