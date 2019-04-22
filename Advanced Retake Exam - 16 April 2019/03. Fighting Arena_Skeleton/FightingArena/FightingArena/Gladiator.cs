using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
   public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            Name = name;
            Stat = stat;
            Weapon = weapon;
        }

        //      •	Name: string
        //  •	Stat: Stat
        //  •	Weapon: Weapon
        //  •	GetTotalPower() : int – return the sum of the stat properties plus the sum of the weapon properties.
        //  •	GetWeaponPower() : int - return the sum of the weapon properties.
        //  •	GetStatPower(): int - return the sum of the stat properties.

        public string Name { get; set; }
        public Stat Stat { get; set; }
        public Weapon Weapon { get; set; }

        public int GetTotalPower()
        {
            var totalPower = GetStatPower() + GetWeaponPower();
            return totalPower;
        }

        public int GetWeaponPower()
        {
            var weaponPower = this.Weapon.Sharpness + this.Weapon.Size + this.Weapon.Solidity;

            return weaponPower;
        }

        public int GetStatPower()
        {
            var statsPower = this.Stat.Agility + this.Stat.Flexibility + this.Stat.Intelligence + this.Stat.Skills +
                             this.Stat.Strength;

            return statsPower;
        }

        public override string ToString()
        {
            var gladiatorInfo = new StringBuilder();
            gladiatorInfo.AppendLine($"[{this.Name}] - [{this.GetTotalPower()}]");
            gladiatorInfo.AppendLine($"  Weapon Power: [{this.GetWeaponPower()}]");
            gladiatorInfo.AppendLine($"  Stat Power: [{this.GetStatPower()}]");

            return gladiatorInfo.ToString().TrimEnd();

        }
    }
}
