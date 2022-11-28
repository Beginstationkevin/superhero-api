using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Dtos.SuperHero;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        public Task<ServiceResponse<GetSuperHeroDto>> GetHero(int id);
        public Task<ServiceResponse<List<GetSuperHeroDto>>> GetHeroes();
        public Task<ServiceResponse<List<GetSuperHeroDto>>> AddHero(AddSuperHeroDto request);
        public Task<ServiceResponse<GetSuperHeroDto>> UpdateHero(UpdateSuperHeroDto request);
        public Task<ServiceResponse<List<GetSuperHeroDto>>> DeleteHero(int id);
    }
}
