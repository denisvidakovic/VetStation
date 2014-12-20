using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace VetStation.CustomDataSources
{
    public class DSAnimal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Age { get; set; }

        public static List<DSAnimal> ModelToCustomDataSource(IEnumerable<Animal> input)
        {
            List<DSAnimal> output = new List<DSAnimal>();

            foreach (Animal animal in input)
            {
                DSAnimal dsAnimal = ModelToCustomDataSource(animal);
                output.Add(dsAnimal);
            }
            return output;
        }

        private static DSAnimal ModelToCustomDataSource(Animal animal)
        {
            DSAnimal dsAnimal = new DSAnimal
                                    {
                                        Id = animal.Id,
                                        Name = animal.Name,
                                        Age = animal.Age,
                                        Breed = animal.Breed.Name
                                    };
            return dsAnimal;
        }
    }
}
