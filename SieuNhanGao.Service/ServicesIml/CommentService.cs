using AutoMapper;
using SieuNhanGao.Data.EF.Entities;
using SieuNhanGao.Infrastructure.Interface;
using SieuNhanGao.Service.IServices;
using SieuNhanGao.Service.ViewModels;
using System;

namespace SieuNhanGao.Service.ServicesIml
{
    public class CommentService : ICommentService
    {
        private IReadRepository<Comment> commentRepository;
        private ICUDRepository<Comment> commentRepositoryCUD;

        private IUnitOfWork unitOfWork;

        public CommentService(IReadRepository<Comment> _commentRepository
                                , IUnitOfWork _unitOfWork
                                , ICUDRepository<Comment> _commentRepositoryCUD)
        {
            commentRepository = _commentRepository;
            unitOfWork = _unitOfWork;
            commentRepositoryCUD = _commentRepositoryCUD;
        }

        public CommentViewModel Add(CommentViewModel comment)
        {
            var cm = Mapper.Map<CommentViewModel, Comment>(comment);
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