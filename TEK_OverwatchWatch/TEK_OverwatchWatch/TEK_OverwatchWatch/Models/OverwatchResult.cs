using System.Collections.Generic;

namespace TEK_OverwatchWatch.Models
{
    public class OverwatchResult
    {
        public int? Total { get; set; }
        public string First { get; set; }
        public object Next { get; set; }
        public object Previous { get; set; }
        public string Last { get; set; }
        public IList<Hero> Data { get; set; }
    }
}
