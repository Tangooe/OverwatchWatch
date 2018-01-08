namespace TEK_OverwatchWatch.Models
{
    public class Ability
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsUltimate { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
    }
}