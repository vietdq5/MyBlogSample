using SieuNhanGao.Infrastructure.DomainEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SieuNhanGao.Data.EF.Entities
{
    [Table("Tag")]
    public class Tag : DomainEntity<int>
    {
        [Required]
        [MaxLength(50)]
        public string TagName { get; set; }

        public ICollection<PostTag> PostTag { get; set; }
    }
}