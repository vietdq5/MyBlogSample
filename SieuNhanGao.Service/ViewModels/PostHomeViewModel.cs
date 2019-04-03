using System;

namespace SieuNhanGao.Service.ViewModels
{
    public class PostHomeViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public DateTime CreateDate { get; set; }
        public string Alias { get; set; }
        public int? ViewCount { get; set; }
        public string ImageAvatar { get; set; }
        public string UserName { get; set; }

        public string DateCreateAgo { get; set; }
    }
}