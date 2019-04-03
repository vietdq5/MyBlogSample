using SieuNhanGao.Service.ViewModels;
using SieuNhanGao.Utilities.Dtos;
using System.Collections.Generic;

namespace SieuNhanGao.Service.IServices
{
    public interface IBusinessRoleService
    {
        IList<BusinessRoleViewModel> GetAll();

        PagedResult<BusinessRoleViewModel> GetAllPaging(string keyword, int page, int pageSize);

        BusinessRoleViewModel Add(BusinessRoleViewModel bussinessRole);

        void Update(BusinessRoleViewModel bussinessRole);

        void Delete(string bussinessRoleId);

        BusinessRoleViewModel FindById(string id);

        void Save();
    }
}