using System;
using System.ComponentModel.DataAnnotations;

namespace SieuNhanGao.Service.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }

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
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public bool Status { get; set; } = false;
        public byte? Report { get; set; }
        public int PostId { get; set; }
    }
}