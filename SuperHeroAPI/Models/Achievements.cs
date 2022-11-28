namespace SuperHeroAPI.Models
{
    public class Achievements
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public SuperHero? SuperHero { get; set; }
    }
}
