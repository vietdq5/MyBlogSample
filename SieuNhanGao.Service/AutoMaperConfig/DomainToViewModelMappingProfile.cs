using AutoMapper;
using SieuNhanGao.Data.EF.Entities;
using SieuNhanGao.Service.ViewModels;

namespace SieuNhanGao.Service.AutoMaperConfig
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<Post, PostViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Comment, CommentViewModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<BusinessRole, BusinessRoleViewModel>();
            CreateMap<Role, RoleViewModel>();
            CreateMap<UserRole, UserRoleViewModel>();
        }
    }
}