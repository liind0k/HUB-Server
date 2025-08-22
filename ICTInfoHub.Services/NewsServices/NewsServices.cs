using ICTInfoHub.Model.Model.DTOs;
using ICTInfoHub.Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ICTInfoHub.Services.NewsServices
{
    public class NewsServices: INewsServices
    {
        private readonly AdminDbContext _context;

        public NewsServices(AdminDbContext context)
        {
            _context = context;
        }
        public async Task<bool> addNews(CreateNewsDTO createNews)
        {
            var admin = await _context.Admins.FindAsync(createNews.AdminId);

            if (admin != null)
            {
                try
                {
                    byte[] DocFile = null;
                    if (createNews.FormFile != null)
                    {
                        var Document = createNews.FormFile;
                        DocFile = await convertToByte(Document);

                    }
                    var campus = await _context.Campuses.FindAsync(createNews.CampusId);

                    var news = new News()
                    {
                        Title = createNews.Title,
                        Description = createNews.Description,
                        Priority = createNews.Priority,
                        Campus = campus,
                        CampusId = createNews.CampusId,
                        Category = createNews.Category,
                        DocFile = DocFile,
                        CreatedAt = DateTime.UtcNow,
                        AdminId = createNews.AdminId,
                        Admin = admin,

                    };
                    _context.Add<News>(news);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> updateNews(UpdateNewsDTO updateNews)
        {
            var News = await _context.News.FindAsync(updateNews.NewsId);

            if (News == null)
            {
                return false;
            }
            else
            {
                try
                {
                    if (updateNews.formFile != null)
                    {
                        byte[] document = await convertToByte(updateNews.formFile);
                        News.DocFile = document;
                    }
                    var campus = _context.Campuses.Find(updateNews.CampusId);

                    News.Title = updateNews.Title;
                    News.Description = updateNews.Description;
                    News.Campus = campus;
                    News.CampusId  = updateNews.CampusId;
                    News.Category = updateNews.Category;
                    News.Priority = updateNews.Priority;
                    _context.Update(News);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }

            }
        }
        public async Task<bool> deleteNews(DeleteNewsDto deleteNews)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Id == deleteNews.AdminId && a.Password == deleteNews.password);
            if (admin != null)
            {

                var News = _context.News.Find(deleteNews.NewsId);
                if (News == null)
                {
                    return false;
                }
                else
                {
                    _context.News.Remove(News);
                    _context.SaveChanges();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        public async Task<List<News>> getAllNews()
        {
            List<News> list = await _context.News.ToListAsync();
            return list;
        }
        public async Task<List<News>> getNewsByCampus(int CampusId)
        {
            List<News> News = await _context.News.Select(a => a).Where(a => a.CampusId ==  CampusId).ToListAsync();
            return News;
        }
        public async Task<bool> tagCampus(TagCampusDTO tagCampusDTO)
        {
            var News = await _context.News.FindAsync(tagCampusDTO.newsId);

            if (News == null)
            {
                return false;
            }
            else
            {
                var campus = await _context.Campuses.FindAsync(tagCampusDTO.campusId);
                News.Campus = campus;
                _context.Update(News);
                _context.SaveChanges();

                return true;
            }
        }
        public async Task<Byte[]> convertToByte(IFormFile formFile)
        {
            using var incomeStream = new MemoryStream();
            await formFile.CopyToAsync(incomeStream);
            byte[] DocFile = incomeStream.ToArray();
            return DocFile;
        }
    }
}
