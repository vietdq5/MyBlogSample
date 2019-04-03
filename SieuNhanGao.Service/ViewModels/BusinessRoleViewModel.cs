using System.ComponentModel.DataAnnotations.Schema;

namespace SieuNhanGao.Service.ViewModels
{
    public class BusinessRoleViewModel
    {
        public string Id { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string BusinessRoleName { get; set; }
    }
}