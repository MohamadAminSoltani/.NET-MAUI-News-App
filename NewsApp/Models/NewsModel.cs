using Newtonsoft.Json;

namespace NewsApp.Models
{
    public class NewsModel
    {
        [JsonProperty("totalArticles")]
        public int TotalArticles { get; set; }
        [JsonProperty("articles")]
        public List<Article> Articles { get; set; }
    }
}
