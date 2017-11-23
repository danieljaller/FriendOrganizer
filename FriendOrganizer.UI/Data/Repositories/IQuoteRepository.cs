using System.Threading.Tasks;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data.Repositories
{
    public interface IQuoteRepository : IGenericRepository<Quote>
    {
        Task<Quote> GenerateQuoteAsync();
    }
}
