using ICTInfoHub.Services.AdminServices;
using ICTInfoHub.Model.Model;
using ICTInfoHub.Model.Model.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ICTInfoHub.API.Controllers
{
    [ApiController]
    [Route("/admin")]
    public class AdminController : ControllerBase
    {        
        IAdminServices _adminServices;
        
        public AdminController(IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }

        [HttpPost("addAdmin")]
        public IActionResult addAdmin(AddAdminDTO admin)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = _adminServices.addAdmin(admin);

            if (res)
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpPost("updateDetails")]
        public IActionResult updateDetails(UpdateDetailsDTO admin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = _adminServices.updateDetails(admin);

            if (res)
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpPost("updateEmail")]
        public IActionResult updateEmail(UpdateEmailDTO admin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

                var res = _adminServices.updateEmail(admin);

                if(res)
                {
                    return StatusCode(201);
                }
                else
                {
                    return StatusCode(400);
                }
                

        }
        
        [HttpPost("updatePassword")]
        public IActionResult updatePassword(UpdatePasswordDTO updatePassword)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = _adminServices.updatePassword(updatePassword);

            if( res)
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(400);
            }
        }


        [HttpPost("AdminLogin")]
        public async Task<IActionResult> AdminLogin(LoginAdminDTO admin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var getAdmin = await _adminServices.loginAsync(admin);

            if (getAdmin == null)
            {
                return StatusCode(400);
            }
            else
            {
                return Ok(getAdmin);
            } 
           
        }
        
    }
}
