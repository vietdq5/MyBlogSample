using SieuNhanGao.Infrastructure.DomainEntity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SieuNhanGao.Data.EF.Entities
{
    [Table("Comment")]
    public class Comment : DomainEntity<int>
    {
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }

        public bool? Status { get; set; }
        public byte? Report { get; set; }
        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}