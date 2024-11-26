using System.ComponentModel.DataAnnotations;

namespace Table_Track.viewModels
{
    public class ApplicationUserVm
    {
        public int id { get; set; }
        [Required]

        public string name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string Confirmpassword { get; set; }
        [Required]

        public string Address { get; set; }


    }
}
