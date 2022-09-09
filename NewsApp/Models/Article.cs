using Newtonsoft.Json;
using SQLite;
using TableAttribute = SQLite.TableAttribute;
using ForeignKeyAttribute = SQLiteNetExtensions.Attributes.ForeignKeyAttribute;
using SQLiteNetExtensions.Attributes;

namespace NewsApp.Models
{
    [Table("articles")]
    public class Article
    {
        [JsonIgnore]
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("publishedAt")]
        public DateTime PublishedAt { get; set; }

        [ForeignKey(typeof(Source))]
        public int SourceId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        [JsonProperty("source")]
        public Source Source { get; set; }
    }
}
