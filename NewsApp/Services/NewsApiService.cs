using NewsApp.Models;
using System.Net.Http.Json;

namespace NewsApp.Services
{
    public class NewsApiService : INewsApiService
    {
        #region Fields
        private readonly string baseUrl = "https://gnews.io/api/v4";
        private HttpClient httpClient;
        #endregion
        public async Task<NewsModel> GetNewsAsync(string topic)
        {
            var networkConnection = Connectivity.NetworkAccess;
            if(networkConnection == NetworkAccess.Internet)
            {
                httpClient = new HttpClient();

                try
                {
                    string query = $"{baseUrl}/top-headlines?token=YOURAPIKEY&lang=en&topic={topic}";

                    var response = await httpClient.GetAsync(query);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadFromJsonAsync<NewsModel>();

                        return result;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {

                    return null;
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Please check your internet Connection", "OK");
                return null;
            }
        }
    }
}
