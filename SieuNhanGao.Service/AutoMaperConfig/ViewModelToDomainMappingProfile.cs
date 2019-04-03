using AutoMapper;
using SieuNhanGao.Data.EF.Entities;
using SieuNhanGao.Service.ViewModels;

namespace SieuNhanGao.Service.AutoMaperConfig
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserViewModel, User>()
           .ConstructUsing(c => new User());

            CreateMap<PostViewModel, Post>()
            .ConstructUsing(c => new Post());

            CreateMap<CategoryViewModel, Category>()
            .ConstructUsing(a => new Category());

            CreateMap<CommentViewModel, Comment>()
           .ConstructUsing(c => new Comment());

            CreateMap<UserViewModel, User>()
           .ConstructUsing(c => new User());

            CreateMap<BusinessRoleViewModel, BusinessRole>()
           .ConstructUsing(c => new BusinessRole());

            CreateMap<RoleViewModel, Role>()
           .ConstructUsing(c => new Role());

            CreateMap<UserRoleViewModel, UserRole>()
            .ConstructUsing(c => new UserRole());
        }
    }
}