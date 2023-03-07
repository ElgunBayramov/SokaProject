using AutoMapper;
using Soka.Domain.AppCode.Infrastructure;
using Soka.Domain.Models.Entities;

namespace Soka.Domain.Mappers.Types
{
    public class TypeProfile : Profile
    {
        public TypeProfile()
        {
            CreateMap<ProductType, HolderChooseModel>()
                .ForMember(dest => dest.Value, src => src.MapFrom(m => m.Name));
        }
    }
}
