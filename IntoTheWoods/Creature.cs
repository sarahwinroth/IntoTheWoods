using System;
using System.Collections.Generic;
using System.Text;

namespace IntoTheWoods
{
    abstract class Creature
    {
        private string name;

        public string Name { get => name; set => name = value; }
    }
}
