using MongoDB.Bson.Serialization.Attributes;

namespace OfficeBall.Api.Models
{
    public class PlayerTag
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}