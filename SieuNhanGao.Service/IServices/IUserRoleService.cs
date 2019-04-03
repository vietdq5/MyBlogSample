using SieuNhanGao.Service.ViewModels;
using System.Collections.Generic;

namespace SieuNhanGao.Service.IServices
{
    public interface IUserRoleService
    {
        IList<PermissionViewModel> userRoles(int userId, string businessRoleId);

        IList<string> UserRolesAuthorizes(int userId);

        UserRoleViewModel FindById(int userId, int roleId);

        UserRoleViewModel Add(UserRoleViewModel userRoleViewModel);

        void Delete(UserRoleViewModel userRoleViewModel);

        void Save();
    }
}