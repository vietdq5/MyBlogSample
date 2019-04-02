using AutoMapper;
using SieuNhanGao.Data.EF.Entities;
using SieuNhanGao.Service.ViewModel;

namespace SieuNhanGao.Service.AutoMaperConfig
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserViewModel, User>()
           .ConstructUsing(c => new User());
        }
    }
}