using Lab6_CSharp.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Collections.Generic;

namespace Lab6_CSharp;

class Program
{
    private static string GetDisplayName(MenuOption option)
    {
        var fieldInfo = typeof(MenuOption).GetField(option.ToString());
        var attribute = fieldInfo?.GetCustomAttribute<DisplayAttribute>();
        return attribute?.GetName() ?? option.ToString();
    }

    private static void TestMeowableCollection(MeowableCounter? existingCounter)
    {
        Console.WriteLine("\n=== Тест задания 2: Интерфейс Мяуканье ===");

        var meowables = new List<IMeowable>();

        if (existingCounter != null)
        {
            meowables.Add(existingCounter);
        }
        else
        {
            meowables.Add(new Cat("Барсик"));
        }

        meowables.Add(new Cat("Мурзик"));
        meowables.Add(new Dog("Шарик"));

        Console.WriteLine("Вызываем meowsCare с коллекцией:");
        Funs.meowsCare(meowables);
        Console.WriteLine();
    }


    private static void DisplayMenu()
    {
        Console.WriteLine("Меню:");
        foreach (var option in Enum.GetValues<MenuOption>())
        {
            Console.WriteLine($"{(int)option}. {GetDisplayName(option)}");
        }
        var min = (int)Enum.GetValues<MenuOption>().Min();
        var max = (int)Enum.GetValues<MenuOption>().Max();
        Console.WriteLine($"Выберите действие({min}-{max})");
    }

    static void Main(string[] args)
    {
        Cat? cat = null;
        MeowableCounter? counter = null;
        bool exit = false;

        Console.WriteLine("=== Управление котом ===");

        while (!exit)
        {
            DisplayMenu();

            if(Enum.TryParse(Console.ReadLine(), out MenuOption choice) && Enum.IsDefined(choice))
                switch (choice)
                {
                    case MenuOption.Create:
                        Console.Write("Введите имя кота: ");
                        cat = new Cat(Console.ReadLine());
                        counter = new MeowableCounter(cat);
                        Console.WriteLine($"Создан кот: {cat}");
                        break;
                    case MenuOption.Display when cat != null: 
                        Console.WriteLine(cat); 
                        break;
                    case MenuOption.MeowOnce when counter != null: 
                        counter.meow(); 
                        break;
                    case MenuOption.MeowNTimes when counter != null: 
                        Console.Write("Введите количество мяуканий (N): ");
                        if (int.TryParse(Console.ReadLine(), out int n))
                        {
                            for (int i = 0; i < n; i++)
                            {
                                counter.meow();
                            }
                        }
                        else Console.WriteLine("Некорректное число!");
                        break;
                    case MenuOption.TestMeowableCollection:
                        TestMeowableCollection(counter);
                        break;
                    case MenuOption.TestMeowCount when counter != null:
                        Console.WriteLine($"\nКот мяукал {counter.MeowCount} раз.");
                        Console.WriteLine();
                        break;
                    case MenuOption.Exit:
                        Console.WriteLine("До свидания!");
                        exit = true;
                        break;
                    default: 
                        Console.WriteLine("Кот еще не создан! Сначала создайте кота.");
                        break;

                }
            else Console.WriteLine($"Неверный выбор! Введите число от 1 до 7.");
        }
    }
}