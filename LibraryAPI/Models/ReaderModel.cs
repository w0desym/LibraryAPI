using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class ReaderModel : IEntityBase
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string BirthDate { get; set; }

        [Required]
        public string Occupation { get; set; }

        [Required]
        public string WorkPlace { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Passport { get; set; }
    }
}
