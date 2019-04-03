using System.ComponentModel.DataAnnotations;

namespace SieuNhanGao.Service.ViewModels
{
    public class TagViewModel
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string TagName { get; set; }
    }
}