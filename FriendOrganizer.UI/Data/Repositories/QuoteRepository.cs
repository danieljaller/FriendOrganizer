using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        private readonly FriendOrganizerDbContext _context;

        public QuoteRepository(FriendOrganizerDbContext context) : base(context)
        {
            _context = context;

            HttpClient.BaseAddress = new Uri("https://talaikis.com/api/quotes/");
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private static readonly HttpClient HttpClient = new HttpClient();

        public async Task<Quote> GenerateQuoteAsync()
        {
            var response = await HttpClient.GetAsync(HttpClient.BaseAddress + "random/");
            if (response.IsSuccessStatusCode)
            {
                var quoteAsString = await response.Content.ReadAsStringAsync();
                return JObject.Parse(quoteAsString).ToObject<Quote>();
            }

            if (_context.Quotes.Any())
            {
                return GetRandomQuoteFromDb();
            }

            throw new Exception("The API is not accessible and there's no quotes in the database");
        }

        private Quote GetRandomQuoteFromDb()
        {
            var rand = new Random();
            var toSkip = rand.Next(0, _context.Quotes.Count());

            return _context.Quotes.OrderBy(r => Guid.NewGuid()).Skip(toSkip).Take(1).First();
        }
    }
}