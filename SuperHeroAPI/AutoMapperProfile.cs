using AutoMapper;
using SuperHeroAPI.Dtos.SuperHero;
using SuperHeroAPI.Dtos.SuperPower;
using SuperHeroAPI.Models;

namespace SuperHeroAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<SuperHero, GetSuperHeroDto>();
            CreateMap<AddSuperHeroDto, SuperHero>();
            CreateMap<SuperPower, GetSuperPowerDto>();
        }
    }
}
