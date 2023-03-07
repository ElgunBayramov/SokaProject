using AutoMapper;
using Soka.Domain.AppCode.Infrastructure;
using Soka.Domain.Models.Entities;

namespace Soka.Domain.Mappers.Sizes
{
    public class SizeProfile : Profile
    {
        public SizeProfile()
        {
            CreateMap<ProductSize, HolderChooseModel>()
                .ForMember(dest => dest.Value, src => src.MapFrom(m => m.Name));
        }
    }
}
