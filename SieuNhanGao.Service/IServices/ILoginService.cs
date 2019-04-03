using SieuNhanGao.Service.ViewModels;

namespace SieuNhanGao.Service.IServices
{
    public interface ILoginService
    {
        UserViewModel checkLogin(string userName, string passWord);

        UserViewModel IsAdmin(int userId);

        void Save();
    }
}