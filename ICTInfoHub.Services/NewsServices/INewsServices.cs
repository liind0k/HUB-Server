using ICTInfoHub.Model.Model.DTOs;
using ICTInfoHub.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ICTInfoHub.Model.Model.DTOs.NewsDTO;

namespace ICTInfoHub.Services.NewsServices
{
    public interface INewsServices
    {
        Task<NewsDTO> getNews(int id);
        Task<List<NewsDTO>> getAllNews();
        Task<bool> addNews(CreateNewsDTO createNewsDTO);
        Task<bool> updateNews(UpdateNewsDTO updateNewsDTO);
        Task<List<News>> getNewsByCampus(int Campus);
        Task<bool> deleteNews(DeleteNewsDto deleteNews);
        Task<bool> updateVisibility(int NewsId);

    }
}
