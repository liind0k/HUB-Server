using ICTInfoHub.Services.NewsServices;
using Microsoft.AspNetCore.Mvc;
using ICTInfoHub.Model.Model;
using ICTInfoHub.Model.Model.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ICTInfoHub.API.Controllers.NewsController
{
    [ApiController]
    [Route("/News")]
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
        [HttpGet("getAllNews")]
        public async Task<IActionResult> getAllNews()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _newsServices.getAllNews();

            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(400);
            }
        }
        [HttpGet("getNews")]
        public async Task<IActionResult> getNews(int newsId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _newsServices.getNews(newsId);

            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(400);
            }
        }
        [HttpGet("getNewsByCampus")]
        public async Task<IActionResult> getNewsByCampus(int CampusId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _newsServices.getNewsByCampus(CampusId);

            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(400);
            }
        }
        [HttpPut("updateVisibility")]
        public async Task<IActionResult> updateAvailability(int NewsId)
        {
            var res = await _newsServices.updateVisibility(NewsId);

            if (res)
            {
                return StatusCode(200);
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
        public async Task<IActionResult> deleteNews(DeleteNewsDto deleteNews)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res =  await _newsServices.deleteNews(deleteNews);

            if (!res)
            {
                return StatusCode(400);
            }
            else
            {
                return StatusCode(201);
            }
        }

    }
}
