using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
    internal class Human2
    {
        // Private variables
        private string firstName = "Pat";
        private string lastName = "Smyth";
        private string eyeColor;
        private int? age;  
        private double weight; 

        // Constructors
        public Human2(string firstName, string lastName, string eyeColor, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyeColor;
            this.age = age;
        }

        public Human2(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public Human2(string firstName, string lastName, string eyeColor)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyeColor;
        }

        public Human2()
        {
            
        }

        public string AboutMe()
    {
        return $"My name is {firstName} {lastName}.";
    }


        // AboutMe2 method
        public string AboutMe2()
        {
            string message = $"My name is {firstName} {lastName}.";

            if (age.HasValue)
                message += $" My age is {age.Value}.";

            if (!string.IsNullOrEmpty(eyeColor))
                message += $" My eye color is {eyeColor}.";

            return message;
        }

        // Weight property with validation
        public double Weight
        {
            get => weight;
            set
            {
                if (value < 0 || value > 400)
                    weight = 0;
                else
                    weight = value;
            }
        }
    }
}