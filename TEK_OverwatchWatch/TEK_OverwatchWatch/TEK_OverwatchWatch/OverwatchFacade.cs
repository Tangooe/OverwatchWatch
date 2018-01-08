using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AppCenter.Analytics;
using TEK_OverwatchWatch.Models;

namespace TEK_OverwatchWatch
{
    public class OverwatchFacade
    {
        private readonly HttpClient _client;

        public OverwatchFacade()
        {
            _client = new HttpClient();
        }

        public IEnumerable<Hero> GetAllHeroes()
        {
            var response = _client.GetAsync(@"https://overwatch-api.net/api/v1/hero").Result;

            if (!response.IsSuccessStatusCode)
                return Enumerable.Empty<Hero>();

            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<OverwatchResult>(content);
            Analytics.TrackEvent($"Successfully retrieved all heroes from the overwatch api");
            var heroes = result.Data.ToList();

            foreach (var hero in heroes)
                SetHeroImage(hero);

            return heroes;
        }

        public Hero GetHero(int id)
        {
            var response = _client.GetAsync(@"https://overwatch-api.net/api/v1/hero/" + id).Result;

            if (!response.IsSuccessStatusCode)
                return null;

            var content = response.Content.ReadAsStringAsync().Result;
            var hero = JsonConvert.DeserializeObject<Hero>(content);
            Analytics.TrackEvent($"Successfully retrieved information on {hero.Name} from the overwatch api");
            SetHeroImage(hero);
            foreach (var ability in hero.Abilities)
            {
                var abilityName = ability.Name
                    .Replace(" ", "-");
                ability.ImageUrl = $"https://d1u1mce87gyfbn.cloudfront.net/hero/{hero.Name}/ability-{abilityName}/icon-ability.png".ToLower();
            }
            return hero;
        }

        private static void SetHeroImage(Hero hero)
        {
            var heroName = hero.Name
                .Replace("ö", "o")
                .Replace(".", "")
                .Replace("ú", "u")
                .Replace(": ", "-");

            hero.ImageUrl = $"https://d1u1mce87gyfbn.cloudfront.net/hero/{heroName}/hero-select-portrait.png".ToLower();
        }
    }
}