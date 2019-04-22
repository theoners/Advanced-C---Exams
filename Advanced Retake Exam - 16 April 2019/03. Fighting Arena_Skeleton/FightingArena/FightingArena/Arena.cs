using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            this.gladiators = new List<Gladiator>();
            this.Name = name;
        }

        public int Count => gladiators.Count;
        public string Name { get; set; }

        public void Add(Gladiator gladiator)
        {
            this.gladiators.Add(gladiator);
        }
        public void Remove(string name)
        {
            var gladiator = gladiators.FirstOrDefault(x => x.Name == name);
            this.gladiators.Remove(gladiator);
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            var maxGladiatorStatPower = 0;
            foreach (var gladiator in gladiators)
            {
                if (maxGladiatorStatPower<gladiator.GetStatPower())
                {
                    maxGladiatorStatPower = gladiator.GetStatPower();
                }
            }

            var currentGladiator = gladiators.FirstOrDefault(x => x.GetStatPower() == maxGladiatorStatPower);
            return currentGladiator;
        }
        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            var maxGladiatorWeaponPower = 0;
            foreach (var gladiator in gladiators)
            {
                if (maxGladiatorWeaponPower < gladiator.GetWeaponPower())
                {
                    maxGladiatorWeaponPower = gladiator.GetWeaponPower();
                }
            }

            var currentGladiator = gladiators.FirstOrDefault(x => x.GetWeaponPower() == maxGladiatorWeaponPower);
            return currentGladiator;
        }
        public Gladiator GetGladitorWithHighestTotalPower()
        {
            var maxGladiatorTotalPower = 0;
            foreach (var gladiator in gladiators)
            {
                if (maxGladiatorTotalPower < gladiator.GetTotalPower())
                {
                    maxGladiatorTotalPower = gladiator.GetTotalPower();
                }
            }

            var currentGladiator = gladiators.FirstOrDefault(x => x.GetTotalPower() == maxGladiatorTotalPower);
            return currentGladiator;
        }

        public override string ToString()
        {
            return $"[{this.Name}] - [{this.Count}] gladiators are participating.";
        }
    }
}
