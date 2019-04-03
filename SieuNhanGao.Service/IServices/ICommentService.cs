using SieuNhanGao.Service.ViewModels;

namespace SieuNhanGao.Service.IServices
{
    public interface ICommentService
    {
        CommentViewModel Add(CommentViewModel comment);

        void Save();
    }
}