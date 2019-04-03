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
    public class CategoryService : ICategoryService
    {
        private IReadRepository<Category> categoryRepository;
        private IReadRepository<PostCategory> postCategoryRepository;

        private IUnitOfWork unitOfWork;

        public CategoryService(IReadRepository<Category> _categoryRepository, IReadRepository<PostCategory> _postCategoryRepository, IUnitOfWork _unitOfWork)
        {
            categoryRepository = _categoryRepository;
            postCategoryRepository = _postCategoryRepository;
            unitOfWork = _unitOfWork;
        }

        public IList<CategoryViewModel> GetAll()
        {
            return categoryRepository.FindAll().ProjectTo<CategoryViewModel>().ToList();
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IList<CategoriesGroupViewModel> GetCategoriesGroup()
        {
            var groupJoin = from pc in postCategoryRepository.FindAll()
                            join c in categoryRepository.FindAll()
                            on pc.CategoryId equals c.Id
                            select new
                            {
                                Id = pc.PostId,
                                CategoryId = pc.CategoryId,
                                CategoryName = c.CategoryName,
                                Url = c.Url
                            };
            var listGroupCount = groupJoin.GroupBy(info => info.CategoryName)
                        .Select(group => new CategoriesGroupViewModel
                        {
                            CategoryName = group.Key,
                            GroupCount = group.Count(),
                        });
            return listGroupCount.ToList();
        }
    }
}