namespace TEK_OverwatchWatch.Models
{
    public class Reward
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Cost Cost { get; set; }
        public string Url { get; set; }
        public Type Type { get; set; }
        public Quality Quality { get; set; }
        public Event Event { get; set; }
    }
}