using System.ComponentModel.DataAnnotations;

namespace SuperHeroAPI.Models
{
    public class SuperPower
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public SuperHero? SuperHero { get; set; }
    }
}
