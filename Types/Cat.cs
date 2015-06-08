using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Types
{
    public class Cat:IAnimal
    {
        public string Type => nameof(Cat);
        public string MakeNoise()
        {
            return $"{Type} says meaaaw";
        }
    }
}
