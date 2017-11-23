using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FriendOrganizer.Model
{
    public class Quote
    {
        public int Id { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("cat")]
        public string Category { get; set; }

        [JsonProperty("quote")]
        public string QuoteText { get; set; }
    }
}
