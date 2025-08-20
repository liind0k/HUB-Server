using ICTInfoHub.Model.Model.DTOs;
using ICTInfoHub.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ICTInfoHub.Services.NewsServices
{
    public interface INewsServices
    {
        
        Task<List<News>> getAllNews();
        Task<bool> addNews(CreateNewsDTO createNewsDTO);
        Task<bool> updateNews(UpdateNewsDTO updateNewsDTO);
        Task<List<News>> getNewsByCampus(string Campus);
        Task<bool> tagCampus(TagCampusDTO tagCampusDTO);
        Task<bool> deleteNews(DeleteNewsDto deleteNews);
    }
}
