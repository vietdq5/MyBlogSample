using System.ComponentModel.DataAnnotations;

namespace SieuNhanGaoBlog.Areas.Admin.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Nhập user vào mày")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Nhập pass vào mày")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}