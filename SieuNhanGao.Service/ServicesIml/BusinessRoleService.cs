using SieuNhanGao.Data.EF.Entities;
using SieuNhanGao.Infrastructure.Interface;
using SieuNhanGao.Service.IServices;
using SieuNhanGao.Service.ViewModel;
using SieuNhanGao.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SieuNhanGao.Service.ServicesIml
{
    public class BusinessRoleService : IBusinessRoleService
    {
        private IReadRepository<BusinessRole> businessRoleRepository;
        private ICUDRepository<BusinessRole> cUDRepository;
        private IReadRepository<Role> roleRepository;
        private ICUDRepository<Role> roleCUDRepository;

        private IUnitOfWork unitOfWork;

        public BusinessRoleService(IReadRepository<BusinessRole> _businessRoleRepository
            , ICUDRepository<BusinessRole> _cUDRepository
            , IReadRepository<Role> _roleRepository
            , ICUDRepository<Role> _roleCUDRepository
            , IUnitOfWork _unitOfWork)
        {
            businessRoleRepository = _businessRoleRepository;
            cUDRepository = _cUDRepository;
            roleRepository = _roleRepository;
            roleCUDRepository = _roleCUDRepository;
            unitOfWork = _unitOfWork;
        }

        public BusinessRoleViewModel Add(BusinessRoleViewModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(BusinessRoleViewModel entity)
        {
            throw new NotImplementedException();
        }

        public PagedResult<BusinessRoleViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Update(BusinessRoleViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
