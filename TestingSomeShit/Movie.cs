using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSomeShit
{
    class Movie
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public String name { get; set; }
        [BsonElement("type")]
        public String type { get; set; }
        [BsonElement("rate")]
        public double rate { get; set; }
        [BsonElement("description")]
        public string description { get; set; }


        public Movie(string name, double rate, string type, string description)
        {
            this.name = name;
            this.type = type;
            this.description = description;
            this.rate = rate;
            
        }
    }
}
