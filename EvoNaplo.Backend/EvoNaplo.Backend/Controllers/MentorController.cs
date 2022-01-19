using EvoNaplo.ApplicationCore.Domains.Users.Models;
using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.Infrastructure.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EvoNaplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private readonly IUserFacade _userFacade;

        public MentorController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [HttpPost]
        public async Task<int> PostAddMentor([FromBody] UserViewModel user)
        {
            await _userFacade.AddUserAsync(user);
            return StatusCodes.Status200OK;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetMentor()
        {
            return await _userFacade.GetAllUserFromRoleTypeAsync(RoleType.Mentor);
        }
    }
}