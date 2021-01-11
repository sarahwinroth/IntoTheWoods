using System;
using System.Collections.Generic;
using System.Text;

namespace IntoTheWoods
{
    class Shop
    {
        private int strengthPotion = 5;
        private int defensePotion = 2;

        public Shop()
        { }

        public int StrengthPotion { get => strengthPotion; set => strengthPotion = value; }
        public int DefensePotion { get => defensePotion; set => defensePotion = value; }

    }
}
