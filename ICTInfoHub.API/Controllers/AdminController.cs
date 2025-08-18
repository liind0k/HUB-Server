using ICTInfoHub.Services.AdminServices;
using ICTInfoHub.Model.Model;
using ICTInfoHub.Model.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ICTInfoHub.API.Controllers
{
    [ApiController]
    [Route("/admin")]
    public class AdminController : ControllerBase
    {        
        IAdminServices adminServices;
        private readonly AdminDbContext _context;

        [HttpPost("addAdmin")]
        public Task<IActionResult> addAdmin(AddAdminDTO admin)
        {
            var res = adminServices.addAdmin(admin);

            if (res)
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(400);
            }
        }
    }
}
