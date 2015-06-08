using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using Types;
using StructureMap.Util;
using StructureMap.Configuration.DSL.Expressions;
using StructureMap.Graph;
using StructureMap.TypeRules;
using StructureMap.Query;


namespace IOC
{
    class Program
    {
        public static Container _container ;

        static void Main(string[] args)
        {
            BuildIOCContainer();
            //InitIoC();
            var animal1 = _container.GetInstance<IAnimal>();

            var animal2 = _container
               .With("Name").EqualTo("Spiffy")
               .GetInstance<IAnimal>();

            Console.WriteLine(animal1.MakeNoise());
            Console.WriteLine(animal2.MakeNoise());

            Console.Write("Press any character to continue...");
            Console.ReadKey();
        }

        private static void InitIoC()
        {
            ObjectFactory.Configure(config =>
            {
                config.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

                // the last entry wins if there's more than one - generally it's a good idea to only have one mapping per type
                config.For<IAnimal>().Use<Dog>();

            });
        }
        private static void BuildIOCContainer()
        {
            _container = new Container(_ =>
            {
                //_.For<IAnimal>().Use<Cat>();


                //dog has multiple ctors, example of using default constructor 
                _.For<IAnimal>().Use<Dog>(x => new Dog()); 

                //_.For<IAnimal>().Use<Dog>().Ctor<string>("name").Is("Fido");
            });

        }
    }

    
}
