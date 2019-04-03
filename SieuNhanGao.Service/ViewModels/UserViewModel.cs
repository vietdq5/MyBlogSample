using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SieuNhanGao.Service.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string Avatar { get; set; }

        public byte? IsAdmin { get; set; }
        public byte? Allowed { get; set; }
    }
}