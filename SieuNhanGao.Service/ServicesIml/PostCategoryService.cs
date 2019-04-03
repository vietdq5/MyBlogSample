using AutoMapper;
using SieuNhanGao.Data.EF.Entities;
using SieuNhanGao.Infrastructure.Interface;
using SieuNhanGao.Service.IServices;
using SieuNhanGao.Service.ViewModels;
using System;

namespace SieuNhanGao.Service.ServicesIml
{
    public class PostCategoryService : IPostCategoryService
    {
        private IReadRepository<PostCategory> commentRepository;
        private ICUDRepository<PostCategory> commentRepositoryCUD;

        private IUnitOfWork unitOfWork;

        public PostCategoryService(IReadRepository<PostCategory> _commentRepository
                                , IUnitOfWork _unitOfWork
                                , ICUDRepository<PostCategory> _commentRepositoryCUD)
        {
            commentRepository = _commentRepository;
            unitOfWork = _unitOfWork;
            commentRepositoryCUD = _commentRepositoryCUD;
        }

        public PostCategoryViewModel Add(PostCategoryViewModel comment)
        {
            var cm = Mapper.Map<PostCategoryViewModel, PostCategory>(comment);
            commentRepositoryCUD.Add(cm);
            return comment;
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}