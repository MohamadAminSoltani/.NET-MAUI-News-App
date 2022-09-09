using NewsApp.Models;

namespace NewsApp.Services
{
    public interface INewsApiService
    {
        Task<NewsModel> GetNewsAsync(string topic);
    }
}
