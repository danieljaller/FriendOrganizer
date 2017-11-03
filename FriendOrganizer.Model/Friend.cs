using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace FriendOrganizer.Model
{
    public class Friend
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        public int? FavoriteLanguageId { get; set; }

        public ProgrammingLanguage FavoriteLanguage { get; set; }
    }
}
