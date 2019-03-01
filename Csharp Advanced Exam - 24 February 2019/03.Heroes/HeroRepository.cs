using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count => data.Count;

        private List<Hero> data;

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            var hero = this.data.FirstOrDefault(x => x.Name == name);
            var heroIndex = data.IndexOf(hero);

            if (hero != null)
            {
                this.data.RemoveAt(heroIndex);
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            return this.data.OrderByDescending(x => x.Item.Strength).FirstOrDefault();
        }

        public Hero GetHeroWithHighestAbility()
        {
            return this.data.OrderByDescending(x => x.Item.Ability).FirstOrDefault();
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            return this.data.OrderByDescending(x => x.Item.Intelligence).FirstOrDefault();
        }

        public override string ToString()
        {

            var repositoryInfo = new StringBuilder();
            foreach (var item in this.data)
            {
                repositoryInfo.Append(item.ToString());
            }
            return repositoryInfo.ToString();
        }
    }
}
