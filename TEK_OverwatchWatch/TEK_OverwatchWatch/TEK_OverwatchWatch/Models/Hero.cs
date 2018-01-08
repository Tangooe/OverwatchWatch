using System;
using System.Collections.Generic;

namespace TEK_OverwatchWatch.Models
{
    public class Hero
    {
        private object _height;
        private string _affilliation;
        private string _baseOfOpperation;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Health { get; set; }
        public int? Armour { get; set; }
        public int? Shield { get; set; }
        public string Real_Name { get; set; }
        public int? Age { get; set; }

        public object Height
        {
            get => _height;
            set => _height = value ?? "Unkown";
        }

        public string Affiliation
        {
            get => _affilliation;
            set => _affilliation = value ?? "Unkown";
        }
        public string Base_Of_Operations
        {
            get => _baseOfOpperation;
            set => _baseOfOpperation = value ?? "Unkown";
        }
        public int? Difficulty { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public Role Role { get; set; }
        public IList<SubRole> SubRoles { get; set; }
        public IList<Ability> Abilities { get; set; }
        public IList<Reward> Rewards { get; set; }
        public string Video { get; set; }
    }
}
