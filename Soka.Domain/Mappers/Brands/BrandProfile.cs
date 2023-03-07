using AutoMapper;
using Soka.Domain.AppCode.Infrastructure;
using Soka.Domain.Models.Entities;

namespace Soka.Domain.Mappers.Brands
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {

            CreateMap<Brand, HolderChooseModel>()
                .ForMember(dest => dest.Value, src => src.MapFrom(m => m.Name));

        }
    }
}
