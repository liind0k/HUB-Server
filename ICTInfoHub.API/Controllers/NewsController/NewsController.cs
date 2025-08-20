using ICTInfoHub.Services.NewsServices;
using Microsoft.AspNetCore.Mvc;
using ICTInfoHub.Model.Model;
using ICTInfoHub.Model.Model.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ICTInfoHub.API.Controllers.NewsController
{
    [ApiController]
    [Route("/news")]
    public class NewsController : ControllerBase
    {
        INewsServices _newsServices;

        public NewsController(INewsServices newsServices)
        {
            _newsServices = newsServices;
        }

        [HttpPost("createNews")]
        public async Task<IActionResult> createNews(CreateNewsDTO createNews)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _newsServices.addNews(createNews);

            if (res)
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpPut("updateNews")]
        public async Task<IActionResult> updateNews(UpdateNewsDTO updateNews)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var res = await _newsServices.updateNews(updateNews);

            if(res)
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpDelete("deleteNews")]
        public IActionResult deleteNews(DeleteNewsDto deleteNews)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = _newsServices.deleteNews(deleteNews);

            if (!res)
            {
                return StatusCode(400);
            }
            else
            {
                return StatusCode(201);
            }
        }

        [HttpGet("getAllNews")]
        public IActionResult getAllNews()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = _newsServices.getAllNews();

            if (res!=null)
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpGet("getNewsByCampus")]
        public async Task<IActionResult> getNewsByCampus(string Campus)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _newsServices.getNewsByCampus(Campus);

            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(400);  
            }
        }

    }
}
