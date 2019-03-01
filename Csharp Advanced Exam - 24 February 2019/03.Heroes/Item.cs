using System.Text;

namespace Heroes
{
    public class Item
    {
        public Item(int strength, int ability, int intelligence)
        {
            this.Strength = strength;
            this.Ability = ability;
            this.Intelligence = intelligence;
        }

        public int Strength { get; set; }

        public int Ability { get; set; }

        public int Intelligence { get; set; }

        public override string ToString()
        {
            var heroesInfo = new StringBuilder();
            heroesInfo.AppendLine($"  * Strength: {this.Strength}");
            heroesInfo.AppendLine($"  * Ability: {this.Ability}");
            heroesInfo.Append($"  * Intelligence: {this.Intelligence}");

            return heroesInfo.ToString();
        }
    }
}
