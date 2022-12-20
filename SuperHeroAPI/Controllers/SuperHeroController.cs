using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Dtos.SuperHero;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.SuperHeroService;
using System.Data;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        /*private readonly DataContext _context;

public SuperHeroController(DataContext context) 
{
_context = context;
}*/

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetSuperHeroDto>>> GetHero(int id)
        {
            /*var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero == null)
                return BadRequest("Hero not found.");

            return Ok(hero);*/
            return Ok(await _superHeroService.GetHero(id));
        }

        [HttpGet, Authorize(Roles = "admin")]
        public async Task<ActionResult<ServiceResponse<List<GetSuperHeroDto>>>> GetHeroes() 
        {
            /*return Ok(await _context.SuperHeroes.ToListAsync());*/
            return Ok(await _superHeroService.GetHeroes());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<SuperHero>>>> AddHero(AddSuperHeroDto request)
        {
            /*_context.SuperHeroes.Add(request);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());*/
            return Ok(await _superHeroService.AddHero(request));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetSuperHeroDto>>>> UpdateHero(UpdateSuperHeroDto request)
        {
            /*var hero = await _context.SuperHeroes.FindAsync(request.Id);

            if (hero == null)
                return BadRequest("Hero not found.");

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());*/
            var serviceResponce = await _superHeroService.UpdateHero(request);
            if (serviceResponce.Data == null)
            {
                return NotFound(serviceResponce);
            }
            return Ok(serviceResponce);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetSuperHeroDto>>>> DeleteHero(int id)
        {
            /*var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero == null)
                return BadRequest("Hero not found.");

            _context.SuperHeroes.Remove(hero);

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());*/
            var serviceResponce = await _superHeroService.DeleteHero(id);
            if (serviceResponce.Data == null)
            {
                return NotFound(serviceResponce);
            }
            return Ok(serviceResponce);
        }
    }
}
