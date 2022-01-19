using EvoNaplo.ApplicationCore.Domains.Users.Models;
using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.Infrastructure.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EvoNaplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdminController : ControllerBase
    {
        private readonly IUserFacade _userFacade;

        public AdminController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [HttpPost]
        public async Task<int> PostAddAdmin([FromBody] UserViewModel user)
        {
            await _userFacade.AddUserAsync(user);
            return StatusCodes.Status200OK;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetAdmin()
        {
            return await _userFacade.GetAllUserFromRoleTypeAsync(RoleType.Admin);
        }
    }
}