using Gospodinov_Bede_task.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gospodinov_Bede_task.Objects
{
    public class Book
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public Book(int id, string author, string title, string decription)
        {
            this.Id = id;
            this.Author = author;
            this.Title = title;
            this.Description = decription;
        }
    }
}
