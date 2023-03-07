using AutoMapper;
using Soka.Domain.AppCode.Infrastructure;
using Soka.Domain.Models.Entities;

namespace Soka.Domain.Mappers.Colors
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<ProductColor, HolderChooseModel>()
                .ForMember(dest => dest.Value, src => src.MapFrom(m => m.Name));
        }
    }
}
