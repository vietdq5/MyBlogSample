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
    public class TagService : ITagService
    {
        private IReadRepository<Tag> _tagRepository;
        private IUnitOfWork _unitOfWork;

        public TagService(IReadRepository<Tag> tagRepository, IUnitOfWork unitOfWork)
        {
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
        }

        public IList<TagViewModel> GetAll()
        {
            return _tagRepository.FindAll().ProjectTo<TagViewModel>().ToList();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}