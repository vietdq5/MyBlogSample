using SieuNhanGao.Infrastructure.DomainEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SieuNhanGao.Data.EF.Entities
{
    [Table("Category")]
    public class Category : DomainEntity<int>
    {
        [MaxLength(100)]
        public string CategoryName { get; set; }

        [Required]
        public int ParentId { get; set; }

        [MaxLength(500)]
        public string IconClass { get; set; }

        [MaxLength(500)]
        public string Url { get; set; }

        public bool? IsParent { get; set; }

        public ICollection<PostCategory> PostCategories { get; set; }

        public Category()
        {
        }
    }
}