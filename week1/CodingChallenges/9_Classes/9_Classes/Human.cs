using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
    internal class Human
    {
        private string firstName = "Pat";
        private string lastName = "Smyth";

        public Human(string FirstName, string lastName)
        {
            this.firstName = FirstName;
            this.lastName = lastName;
        }

        public Human()
        {

        }

        public string AboutMe()
        {
            return $"My name is {firstName} {lastName}.";
        }
    }//end of class
}//end of namespace