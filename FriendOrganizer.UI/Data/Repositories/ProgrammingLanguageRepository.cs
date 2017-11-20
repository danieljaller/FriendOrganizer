using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System.Data.Entity;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data.Repositories
{
  public class ProgrammingLanguageRepository
  : GenericRepository<ProgrammingLanguage, FriendOrganizerDbContext>,
    IProgrammingLanguageRepository
  {
    public ProgrammingLanguageRepository(FriendOrganizerDbContext context)
      : base(context)
    {
    }
  }
}
