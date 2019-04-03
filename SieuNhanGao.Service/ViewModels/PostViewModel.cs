using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SieuNhanGao.Service.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [MaxLength(500)]
        [Required]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string Content { get; set; }

        [MaxLength(256)]
        public string Thumbnail { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdateDate { get; set; }

        public byte Status { get; set; }
        public string Alias { get; set; }
        public int UserId { get; set; }
        public int? ViewCount { get; set; }

        public IList<string> ListTag { get; set; }
        public IList<string> ListMenu { get; set; }
    }
}