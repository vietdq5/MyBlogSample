using SieuNhanGao.Infrastructure.DomainEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SieuNhanGao.Data.EF.Entities
{
    [Table("Role")]
    public class Role : DomainEntity<int>
    {
        public string RoleName { get; set; }
        public string Description { get; set; }
        public string BusinessRoleId { get; set; }

        public BusinessRole BusinessRole { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}