using System;

namespace Lab6_CSharp.Models
{
    internal class Dog : IMeowable
    {
        private string _name;

        public Dog(string name)
        {
            _name = name;
        }

        public string Name
        {
            get 
            { 
                return _name; 
            }
        }

        public void meow()
        {
            Console.WriteLine($"{_name}: мя... гав! (ну... он пытался...)");
        }
    }
}
