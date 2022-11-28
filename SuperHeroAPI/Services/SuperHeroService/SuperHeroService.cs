using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Dtos.SuperHero;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public SuperHeroService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetSuperHeroDto>>> AddHero(AddSuperHeroDto request)
        {
            ServiceResponse<List<GetSuperHeroDto>> serviceResponse = new ServiceResponse<List<GetSuperHeroDto>>();
            SuperHero superHero = _mapper.Map<SuperHero>(request);
            _context.SuperHeroes.Add(superHero);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.SuperHeroes.Select(sh => _mapper.Map<GetSuperHeroDto>(sh)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetSuperHeroDto>>> DeleteHero(int id)
        {
            ServiceResponse<List<GetSuperHeroDto>> serviceResponse = new ServiceResponse<List<GetSuperHeroDto>>();

            try
            {
                SuperHero superHero = await _context.SuperHeroes.FirstOrDefaultAsync(sh => sh.Id == id);
                if (superHero != null)
                {
                    _context.SuperHeroes.Remove(superHero);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = _context.SuperHeroes.Select(sh => _mapper.Map<GetSuperHeroDto>(sh)).ToList();
                }
                else 
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Superhero not found";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSuperHeroDto>> GetHero(int id)
        {
            ServiceResponse<GetSuperHeroDto> serviceResponse = new ServiceResponse<GetSuperHeroDto>();
            SuperHero superHero = await _context.SuperHeroes.FirstOrDefaultAsync(sh => sh.Id == id);
            serviceResponse.Data = _mapper.Map<GetSuperHeroDto>(superHero);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetSuperHeroDto>>> GetHeroes()
        {
            ServiceResponse<List<GetSuperHeroDto>> serviceResponse = new ServiceResponse<List<GetSuperHeroDto>>();
            List<SuperHero> superHeroes = await _context.SuperHeroes.Include(sh => sh.SuperPower).ToListAsync();
            serviceResponse.Data = superHeroes.Select(sh => _mapper.Map<GetSuperHeroDto>(sh)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSuperHeroDto>> UpdateHero(UpdateSuperHeroDto request)
        {
            ServiceResponse<GetSuperHeroDto> serviceResponse = new ServiceResponse<GetSuperHeroDto>();

            try
            {
                SuperHero superHero = await _context.SuperHeroes.FirstOrDefaultAsync(sh => sh.Id == request.Id);
                superHero.Name = request.Name;
                superHero.FirstName = request.FirstName;
                superHero.LastName = request.LastName;
                superHero.Place = request.Place;

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetSuperHeroDto>(superHero);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
