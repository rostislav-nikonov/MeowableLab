using System.ComponentModel.DataAnnotations;

namespace Lab6_CSharp.Models;

public enum MenuOption
{
    [Display(Name = "Создать нового кота")]
    Create = 1,
    [Display(Name = "Вывести информацию о коте")]
    Display,
    [Display(Name = "Мяукнуть N раз")]
    MeowNTimes,
    [Display(Name = "Мяукнуть 1 раз")]
    MeowOnce,
    [Display(Name = "Тест задания 2: коллекция мяукающих объектов")]
    TestMeowableCollection,
    [Display(Name = "Тест задания 3: подсчет мяуканий")]
    TestMeowCount,
    [Display(Name = "Выход")]
    Exit
}
