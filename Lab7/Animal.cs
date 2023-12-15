using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{


    [System.AttributeUsage(System.AttributeTargets.Class)]
    class CustomCommentAttribute: System.Attribute 
    {
        public string Comment;
        public CustomCommentAttribute(string com) 
        {
            Comment = com;
        }

    }

    [CustomComment("Animal class")]
    public class Animal
    {
        public string Country { get; set; }
        public bool HideFromOtherAnimals { get; set; }

        public string Name { get; set; }

        public eClassificationAnimal WhatAnimal { get; set; }


        public Animal() { }

        public Animal(string country, bool hiding, string name) 
        {
            Country = country;
            HideFromOtherAnimals = hiding;
            Name = name;
        }

        public virtual void Deconstruct() { }

        public eClassificationAnimal GetClassificationAnimal() { return WhatAnimal; }

        public virtual eFavoriteFood GetFavoriteFood() 
        {
            return WhatAnimal switch
            {
                eClassificationAnimal.Carnivores => eFavoriteFood.Meat,
                eClassificationAnimal.Herbivores => eFavoriteFood.Plants,
                _ => eFavoriteFood.Everything
            };
        }

        public virtual string SayHello()
        {
            return "Hello, Im animal";
        }
    }

    public enum eClassificationAnimal 
    {
        Herbivores,
        Carnivores,
        Omnivores
    }

    public enum eFavoriteFood 
    {
        Meat,
        Plants,
        Everything
    }

    [CustomComment("Cow class")]
    public class Cow: Animal
    {
        public Cow() { }

        public Cow(string country, bool hiding, string name) : base(country, hiding, name) 
        {
            WhatAnimal = eClassificationAnimal.Herbivores;
        
        }

        public override eFavoriteFood GetFavoriteFood()
        {
            return eFavoriteFood.Plants;
        }

        public override string SayHello() 
        {
            return "Moo..";
        
        }


    }
    [CustomComment("Lion class")]
    public class Lion : Animal
    {
        public Lion() { }

        public Lion(string country, bool hiding, string name) : base(country, hiding, name)
        {
            WhatAnimal = eClassificationAnimal.Carnivores;

        }

        public override eFavoriteFood GetFavoriteFood() { return eFavoriteFood.Meat; }
      //  {
       //     return eFavoriteFood.Meat;
       // }

        public override string SayHello()
        {
            return "Rrrooarr..";

        }


    }

    [CustomComment("Pig class")]
    public class Pig : Animal
    {
        public Pig() { }

        public Pig(string country, bool hiding, string name) : base(country, hiding, name)
        {
            WhatAnimal = eClassificationAnimal.Omnivores;

        }

        public override eFavoriteFood GetFavoriteFood()
        {
            return eFavoriteFood.Everything;
        }

        public override string SayHello()
        {
            return "Uii..";

        }


    }


}