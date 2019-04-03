using SieuNhanGao.Service.ViewModels;
using System.Collections.Generic;

namespace SieuNhanGao.Service.IServices
{
    public interface IUserService
    {
        IList<UserViewModel> GetAll();

        UserViewModel FindById(int userId);

        UserViewModel Add(UserViewModel userViewModel);

        void Update(UserViewModel userViewModel);

        void Delete(int userId);

        void Save();
    }
}