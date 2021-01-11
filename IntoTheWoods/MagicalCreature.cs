using System;
using System.Collections.Generic;
using System.Text;

namespace IntoTheWoods
{
    class MagicalCreature : Creature
    {
        private int hp = 50;
        private int exp;
        private int strength;
        private string attackMethod1;
        private string attackMethod2;
        private int gold = 25;

        public MagicalCreature(string name, int exp, int strength, string attackMethod1, string attackMethod2)
        {
            this.Name = name;
            this.exp = exp;
            this.strength = strength;
            this.attackMethod1 = attackMethod1;
            this.attackMethod2 = attackMethod2;           
        }

        public int Hp { get => hp; set => hp = value; }
        public int Exp { get => exp; set => exp = value; }
        public int Strength { get => strength; set => strength = value; }
        public string AttackMethod1 { get => attackMethod1; set => attackMethod1 = value; }
        public string AttackMethod2 { get => attackMethod2; set => attackMethod2 = value; }
        public int Gold { get => gold; set => gold = value; }

        public string GetRandomAttack()
        {
            Random random = new Random();
            int rand = random.Next(2);

            if (rand == 0)
            {
                return attackMethod1;
            }
            if(rand == 1)
            {
                return attackMethod2;
            }
            else { return attackMethod1; }
        }
    }
}
