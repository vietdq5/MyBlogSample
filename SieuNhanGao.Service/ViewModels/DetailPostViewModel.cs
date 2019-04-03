using System.Collections.Generic;

namespace SieuNhanGao.Service.ViewModels
{
    public class DetailPostViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public string Author { get; set; }
        public string Avatar { get; set; }
        public string DateAgo { get; set; }
        public int ViewCount { get; set; }
        public IEnumerable<TagViewModel> Tags { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
        public IEnumerable<CommentInPostViewModel> Comments { get; set; }
        public PostViewModel PreviousPost { get; set; }
        public PostViewModel NextPost { get; set; }
    }
}