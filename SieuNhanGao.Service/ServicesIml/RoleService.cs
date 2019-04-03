using AutoMapper;
using AutoMapper.QueryableExtensions;
using SieuNhanGao.Data.EF.Entities;
using SieuNhanGao.Infrastructure.Interface;
using SieuNhanGao.Service.IServices;
using SieuNhanGao.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SieuNhanGao.Service.ServicesIml
{
    public class RoleService : IRoleService
    {
        private IReadRepository<Role> roleRepository;
        private ICUDRepository<Role> roleCUDRepository;

        private IUnitOfWork unitOfWork;

        public RoleService(IReadRepository<Role> _roleRepository
            , ICUDRepository<Role> _roleCUDRepository
            , IUnitOfWork _unitOfWork)
        {
            roleRepository = _roleRepository;
            roleCUDRepository = _roleCUDRepository;
            unitOfWork = _unitOfWork;
        }

        public RoleViewModel Add(RoleViewModel roleViewModel)
        {
            var role = Mapper.Map<RoleViewModel, Role>(roleViewModel);
            roleCUDRepository.Add(role);
            return roleViewModel;
        }

        public RoleViewModel FindById(int id)
        {
            return Mapper.Map<Role, RoleViewModel>(roleRepository.FindSingle(s => s.Id == id));
        }

        public IList<RoleViewModel> GetAll()
        {
            return roleRepository.FindAll().ProjectTo<RoleViewModel>().ToList();
        }

        public IList<RoleViewModel> GetAllWithBusinessRole(string businessId)
        {
            return roleRepository.FindAll(s => s.BusinessRoleId == businessId).ProjectTo<RoleViewModel>().ToList();
        }

        public IList<PermissionViewModel> GetRolesWithBusinessRoleId(string businessRoleId)
        {
            var rolesWithBusinessId = from p in roleRepository.FindAll(s => s.BusinessRoleId == businessRoleId)
                                      select new PermissionViewModel
                                      {
                                          RoleId = p.Id,
                                          RoleName = p.RoleName,
                                          Description = p.Description,
                                          IsGranted = false
                                      };
            return rolesWithBusinessId.ToList();
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void Update(RoleViewModel roleViewModel)
        {
            roleCUDRepository.Update(Mapper.Map<RoleViewModel, Role>(roleViewModel));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}