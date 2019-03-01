using System.Text;

namespace Heroes
{
    public class Hero
    {
        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public string Name { get; set; }

        public int Level { get; set; }

        public Item Item { get; set; }

        public override string ToString()
        {
            var heroesInfo = new StringBuilder();
            heroesInfo.AppendLine($"Hero: {Name} – {Level}lvl");
            heroesInfo.AppendLine($"Item:");
            heroesInfo.AppendLine(this.Item.ToString());

            return heroesInfo.ToString();
        }
    }
}
