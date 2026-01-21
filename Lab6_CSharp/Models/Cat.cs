using System;

namespace Lab6_CSharp.Models
{
    internal class Cat : IMeowable
    {
        private string _name;
        public Cat(string name)
        {
            Name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }
                else
                {
                    Console.WriteLine("Ошибка имени, оно не может быть пустым");
                    _name = "Барсик";
                }
            }
        }

        public override string ToString()
        {
            return $"кот: {Name}";
        }

        public void meow()
        {
            Meow();
        }

        public void Meow()
        {
            Console.WriteLine($"{Name}: мяу!");
        }

        public void Meow(int n)
        {
            if (n <= 0)
            {
                Console.WriteLine($"{Name}: ... (а в ответ тишина)");
                return;
            }

            string meows = string.Join("", Enumerable.Repeat("мяу", n));

            if (n > 1)
            {
                meows = string.Join("-", Enumerable.Repeat("мяу", n));
            }

            Console.WriteLine($"{Name}: {meows}!");
        }
    }
}