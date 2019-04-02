using AutoMapper;
using SieuNhanGao.Data.EF.Entities;
using SieuNhanGao.Service.ViewModel;

namespace SieuNhanGao.Service.AutoMaperConfig
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}