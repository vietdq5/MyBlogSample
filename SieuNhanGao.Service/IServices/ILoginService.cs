using SieuNhanGao.Service.ViewModel;

namespace SieuNhanGao.Service.IServices
{
    public interface ILoginService
    {
        UserViewModel checkLogin(string userName, string passWord);
        void Save();
    }
}