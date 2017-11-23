using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using Newtonsoft.Json.Linq;

namespace FriendOrganizer.UI.Data.Repositories
{
    public class QuoteRepository : GenericRepository<Quote, FriendOrganizerDbContext>, IQuoteRepository
    {
        public QuoteRepository(FriendOrganizerDbContext context) : base(context)
        {
        }

        private static readonly HttpClient HttpClient = new HttpClient();

        public async Task<Quote> GenerateQuoteAsync()
        {
            HttpClient.BaseAddress = new Uri("https://talaikis.com/api/quotes/random/");
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await HttpClient.GetAsync(HttpClient.BaseAddress);
            
            if (response.IsSuccessStatusCode)
            {
                var quoteAsString = await response.Content.ReadAsStringAsync();
                return JObject.Parse(quoteAsString).ToObject<Quote>();
            }
            else
            {
                throw new Exception("Something went wrong");
            }

        }
    }
}
