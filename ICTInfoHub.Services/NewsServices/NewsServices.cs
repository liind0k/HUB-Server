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
        public async Task<bool> addNews(CreateNewsDTO dto)
        {
            var admin = await _context.Admins.FindAsync(dto.AdminId);

            if (admin != null)
            {
                
                    Byte[] docFile = null;

                    if (dto.FormFile!= null)
                    {
                        docFile = await convertToByte(dto.FormFile);
                    }
                    var news = new News
                    {
                        AdminId = dto.AdminId,
                        NewsTitle = dto.Title,
                        NewsDescription = dto.Description,
                        IsVisible = false,
                        Priority = dto.Priority,
                        Category = dto.Category,
                        DocFile = docFile,
                        Campuses = new List<Campus>(),
                    };
                    if (dto.CampusIds != null && dto.CampusIds.Any())
                    {
                        var campuses = await _context.Campuses
                                                     .Where(c => dto.CampusIds.Contains(c.CampusId))
                                                     .ToListAsync();
                        foreach (var campus in campuses)
                        {
                            news.Campuses.Add(campus);
                        }
                    }

                    _context.News.Add(news);
                    await _context.SaveChangesAsync();
                    return true;
                
            }
            else
            {
                throw new Exception("User not found."); ;
            }
        }
        public async Task<bool> updateNews(UpdateNewsDTO dto)
        {
            var News = await _context.News.FindAsync(dto.NewsId);

            if (News == null)
            {
                throw new Exception("News not found."); ;
            }
            else
            {
                try
                {
                    if (dto.formFile != null)
                    {
                        Byte[] document = await convertToByte(dto.formFile);
                        News.DocFile = document;
                    }

                    News.NewsTitle = dto.Title;
                    News.NewsDescription = dto.Description;
                    News.Category = dto.Category;
                    News.Priority = dto.Priority;

                    News.Campuses.Clear();
                    if (dto.CampusIds != null && dto.CampusIds.Any())
                    {
                        var campuses = await _context.Campuses
                                                     .Where(c => dto.CampusIds.Contains(c.CampusId))
                                                     .ToListAsync();
                        foreach (var campus in campuses)
                        {
                            News.Campuses.Add(campus);
                        }
                    }

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
            
            Campus Campus = await _context.Campuses
                            .Include( c => c.News)
                            .FirstOrDefaultAsync(c => c.CampusId ==CampusId);
            if(Campus == null)
            {
                return null;
            }
            else
            {
                List<News> news =  Campus.News.ToList();
                return news;
            }
            
        }
        public async Task<Byte[]> convertToByte(IFormFile formFile)
        {
            using var incomeStream = new MemoryStream();
            await formFile.CopyToAsync(incomeStream);
            byte[] DocFile = incomeStream.ToArray();
            return DocFile;
        }
        public async Task<bool> updateVisibility(int NewsId)
        {
            var news = await _context.News.FindAsync(NewsId);
            
            if(news != null)
            {
                if (news.IsVisible)
                {
                    news.IsVisible = false;
                }
                else
                {
                    news.IsVisible = true;
                }
                
                _context.News.Update(news);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<News> getNews(int NewsId)
        {
            var news = await _context.News.FindAsync(NewsId);
            return news;
        }
    }
}
