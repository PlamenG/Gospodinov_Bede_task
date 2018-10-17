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
        public long Id { get; private set; }

        [JsonProperty("author")]
        public string Author { get; private set; }

        [JsonProperty("title")]
        public string Title { get; private set; }

        [JsonProperty("description")]
        public string Description { get; private set; }

        public Book(long id, string author, string title, string decription)
        {
            this.Id = id;
            this.Author = author;
            this.Title = title;
            this.Description = decription;
        }
    }
}
