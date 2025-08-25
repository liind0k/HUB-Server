using ICTInfoHub.Model.Model.DTOs;
using ICTInfoHub.Services.ServiceServices;
using Microsoft.AspNetCore.Mvc;

namespace ICTInfoHub.API.Controllers.ServiceController
{
    [ApiController]
    [Route("/Service")]
    public class ServiceController: ControllerBase
    {
        IServiceServices _serviceServices;

        public ServiceController(IServiceServices serviceServices)
        {
            _serviceServices = serviceServices;
        }

        [HttpGet("getAllServices")]
        public async Task<IActionResult> GetAllServices() 
        {
            var res = await _serviceServices.getAllServices();

            if (res == null) 
            {
                return StatusCode(400);
            }
            else
            {
                return Ok(res);
            }
        }
        [HttpGet("getService")]
        public async Task<IActionResult> GetService(int ServiceId)
        {
            var res = await _serviceServices.getService(ServiceId);

            if (res == null)
            {
                return StatusCode(400);
            }
            else
            {
                return Ok(res);
            }
        }
        [HttpPut("updatePhone")]
        public async Task<IActionResult> updateServicePhone(UpdateServiceContactsDTO updateServiceContacts)
        {
            var res = await _serviceServices.updateServicePhone(updateServiceContacts);

            if (res)
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(400);
            }
        }
        [HttpPut("updateEmail")]
        public async Task<IActionResult> updateServiceEmail(UpdateServiceContactsDTO updateServiceContacts)
        {
            var res = await _serviceServices.updateServiceEmail(updateServiceContacts);

            if (res)
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(400);
            }
        }
        [HttpPut("updateLocation")]
        public async Task<IActionResult> updateServiceLocation(UpdateServiceContactsDTO updateServiceContacts)
        {
            var res = await _serviceServices.updateServiceLocation(updateServiceContacts);

            if (res)
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(400);
            }
        }
        [HttpPut("updateSteps")]
        public async Task<IActionResult> updateServiceSteps(UpdateStepsDTO updateSteps)
        {
            var res = await _serviceServices.updateServiceSteps(updateSteps);

            if (res)
            {
                return Ok();
            }
            else
            {
                return StatusCode(400);
            }
        }
    }
}
