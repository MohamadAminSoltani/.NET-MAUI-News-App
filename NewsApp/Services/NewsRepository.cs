using NewsApp.Models;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;

namespace NewsApp.Services
{
    public class NewsRepository
    {
        string _dbPath;
        private SQLiteAsyncConnection _connection;

        public const SQLite.SQLiteOpenFlags Flags = 
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        private async Task Init()
        {
            if (_connection != null)
                return;

            _connection = new SQLiteAsyncConnection(_dbPath, Flags);
            await _connection.CreateTableAsync<Source>();
            await _connection.CreateTableAsync<Article>();
        }

        public NewsRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async Task AddNewArticle(Article article)
        {
            try
            {
                await Init();
                if(article is null)
                    throw new Exception("Valid Article Required");

                if(article.Id == 0)
                {
                    await _connection.InsertWithChildrenAsync(article);
                }
                else
                {
                    await _connection.UpdateWithChildrenAsync(article);
                }
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Error", "Error", "OK");
            }
        }

        public async Task<List<Article>> GetAllArticles()
        {
            try
            {
                await Init();
                return await _connection.GetAllWithChildrenAsync<Article>();
            }
            catch (Exception ex)
            {

                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }

            return new List<Article>();
        }

    }
}
