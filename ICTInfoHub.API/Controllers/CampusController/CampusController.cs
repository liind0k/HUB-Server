using ICTInfoHub.Services.CampusServices;
using Microsoft.AspNetCore.Mvc;



namespace ICTInfoHub.API.Controllers.CampusController
{
    [ApiController]
    [Route("/Campus")]
    public class CampusController: ControllerBase
    {
        ICampusServices _campusServices;

        public CampusController(ICampusServices campusServices)
        {
            _campusServices = campusServices;
        }

        [HttpGet("getCampus")]
        public async Task<IActionResult> getCampus(int CampusId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var campus = await _campusServices.getCampus(CampusId);

            if(campus != null)
            {
                return Ok(new { data = campus });
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpGet("getAllCampus")]
        public async Task<IActionResult> getAllCampus()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var campuses = await _campusServices.getCampusList();

            if (campuses != null)
            {
                return Ok(new { data= campuses });
            }
            else
            {
                return StatusCode(400);
            }
        }
    }
}
