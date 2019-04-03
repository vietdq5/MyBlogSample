using AutoMapper;
using AutoMapper.QueryableExtensions;
using SieuNhanGao.Data.EF.Entities;
using SieuNhanGao.Infrastructure.Interface;
using SieuNhanGao.Service.IServices;
using SieuNhanGao.Service.ViewModels;
using SieuNhanGao.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SieuNhanGao.Service.ServicesIml
{
    public class BusinessRoleService : IBusinessRoleService
    {
        private IReadRepository<BusinessRole> businessRoleRepository;
        private ICUDRepository<BusinessRole> brCUDRepository;

        private IUnitOfWork unitOfWork;

        public BusinessRoleService(IReadRepository<BusinessRole> _businessRoleRepository
            , ICUDRepository<BusinessRole> _cUDRepository
            , IUnitOfWork _unitOfWork)
        {
            businessRoleRepository = _businessRoleRepository;
            brCUDRepository = _cUDRepository;
            unitOfWork = _unitOfWork;
        }

        public BusinessRoleViewModel Add(BusinessRoleViewModel bussinessRole)
        {
            var business = Mapper.Map<BusinessRoleViewModel, BusinessRole>(bussinessRole);
            brCUDRepository.Add(business);
            return bussinessRole;
        }

        public void Delete(string bussinessRoleId)
        {
            var businessRole = businessRoleRepository.FindSingle(s => s.Id == bussinessRoleId);
            brCUDRepository.Remove(businessRole);
        }

        public BusinessRoleViewModel FindById(string id)
        {
            return Mapper.Map<BusinessRole, BusinessRoleViewModel>(businessRoleRepository.FindSingle(s => s.Id == id));
        }

        public IList<BusinessRoleViewModel> GetAll()
        {
            return businessRoleRepository.FindAll().ProjectTo<BusinessRoleViewModel>().ToList();
        }

        public PagedResult<BusinessRoleViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void Update(BusinessRoleViewModel bussinessRole)
        {
            brCUDRepository.Update(Mapper.Map<BusinessRoleViewModel, BusinessRole>(bussinessRole));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}