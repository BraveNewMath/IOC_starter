using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Types
{
    public class Dog:IAnimal
    {
        public Dog()
        {
            Name = "unnamed";
        }

        public Dog(string name)
        {
            Name = name;
        }

        public String Name { get; set; }
        public string Type => nameof(Dog);

        public string MakeNoise()
        {
            return $"A {Type} named {Name} says woof";
        }
    }
}
