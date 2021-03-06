using EvoNaplo.ApplicationCore.Domains.Users.Models;
using EvoNaplo.Infrastructure.DomainFacades;
using EvoNaplo.Infrastructure.Models.DTO;
using EvoNaplo.Infrastructure.Models.Entities;
using EvoNaplo.Infrastructure.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EvoNaplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUserFacade _userFacade;

        public StudentController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [HttpPost("AddStudent")]
        public async Task<int> PostAddStudent([FromBody] UserViewModel user)
        {
            await _userFacade.AddUserAsync(user);
            return StatusCodes.Status200OK;
        }

        [HttpGet("EmailExists")]
        public EmailViewModel EmailExists(string email)
        {
            return _userFacade.IsEmailExists(email);
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetStudentAsync()
        {
            return await _userFacade.GetAllUserFromRoleTypeAsync(RoleType.Student);
        }

        ////PUT
        //// api/Student/edit jsonben paramból id és bodyból studentDto
        //[HttpPut("edit")]
        //public async Task<int> PutEditStudent(int id, StudentDto studentDto)
        //{
        //    await _studentService.EditStudent(id, studentDto);
        //    return StatusCodes.Status200OK;
        //}

        ////PUT
        //// api/Student/inactivate jsonben paramból id
        //[HttpPut("inactivate")]
        //public async Task<int> PutInactivateStudent(int id)
        //{
        //    await _studentService.InactivateStudent(id);
        //    return StatusCodes.Status200OK;
        //}

        //Delete
        // api/Student/delete jsonben paramból id
        [HttpDelete("DELETE")]
        public async Task<int> DeleteUser(int id)
        {
            await _userFacade.DeleteUserAsync(id);
            return StatusCodes.Status200OK;
        }
    }
}