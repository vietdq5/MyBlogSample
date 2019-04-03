using System.ComponentModel.DataAnnotations;

namespace SieuNhanGao.Service.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string CategoryName { get; set; }

        [Required]
        public int ParentId { get; set; }

        [MaxLength(500)]
        public string IconClass { get; set; }

        [MaxLength(500)]
        public string Url { get; set; }

        public bool? IsParent { get; set; }
    }
}