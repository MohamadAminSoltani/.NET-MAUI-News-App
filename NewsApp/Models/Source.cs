using Newtonsoft.Json;
using SQLite;

namespace NewsApp.Models
{
    [Table("sources")]
    public class Source
    {
        [JsonIgnore]
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
