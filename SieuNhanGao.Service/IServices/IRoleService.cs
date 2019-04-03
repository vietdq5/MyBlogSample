using SieuNhanGao.Service.ViewModels;
using System.Collections.Generic;

namespace SieuNhanGao.Service.IServices
{
    public interface IRoleService
    {
        //get all record in table
        IList<RoleViewModel> GetAll();

        IList<RoleViewModel> GetAllWithBusinessRole(string businessId);

        IList<PermissionViewModel> GetRolesWithBusinessRoleId(string businessRoleId);

        RoleViewModel FindById(int id);

        RoleViewModel Add(RoleViewModel roleViewModel);

        void Update(RoleViewModel roleViewModel);

        void Save();
    }
}