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
    public class UserRoleService : IUserRoleService
    {
        private IReadRepository<Role> roleRepository;
        //private ICUDRepository<Role> brCUDRepository;

        private IReadRepository<UserRole> userRoleRepository;
        private ICUDRepository<UserRole> urCUDRepository;

        private IUnitOfWork unitOfWork;

        public UserRoleService(IReadRepository<Role> _roleRepository
            , IReadRepository<UserRole> _userRoleRepository
            , ICUDRepository<UserRole> _urCUDRepository
            , IUnitOfWork _unitOfWork)
        {
            roleRepository = _roleRepository;
            userRoleRepository = _userRoleRepository;
            urCUDRepository = _urCUDRepository;
            unitOfWork = _unitOfWork;
        }

        public UserRoleViewModel Add(UserRoleViewModel userRoleViewModel)
        {
            var userrole = Mapper.Map<UserRoleViewModel, UserRole>(userRoleViewModel);
            urCUDRepository.Add(userrole);
            return userRoleViewModel;
        }

        public void Delete(UserRoleViewModel userRoleViewModel)
        {
            var role = Mapper.Map<UserRoleViewModel, UserRole>(userRoleViewModel);
            urCUDRepository.Remove(role);
        }

        public UserRoleViewModel FindById(int userId, int roleId)
        {
            return userRoleRepository.FindAll(s => s.UserId == userId && s.RoleId == roleId).ProjectTo<UserRoleViewModel>().SingleOrDefault();
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public IList<PermissionViewModel> userRoles(int userId, string businessRoleId)
        {
            //lay tat ca cac rolesname cua user va business
            var listuserRoles = from g in userRoleRepository.FindAll(s => s.UserId == userId)
                                join p in roleRepository.FindAll(s => s.BusinessRoleId == businessRoleId)
                                on g.RoleId equals p.Id
                                select new PermissionViewModel
                                {
                                    RoleId = p.Id,
                                    RoleName = p.RoleName,
                                    Description = p.Description,
                                    IsGranted = true
                                };

            return listuserRoles.ToList();
        }

        public IList<string> UserRolesAuthorizes(int userId)
        {
            //lay tat ca cac rolesname cua user va business
            var listuserRoles = from g in userRoleRepository.FindAll(s => s.UserId == userId)
                                join p in roleRepository.FindAll()
                                on g.RoleId equals p.Id
                                select p.RoleName;
            return listuserRoles.ToList();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}