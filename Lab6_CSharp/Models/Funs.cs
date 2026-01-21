using System.Collections.Generic;

namespace Lab6_CSharp.Models
{
    internal static class Funs
    {
        public static void meowsCare(IEnumerable<IMeowable> meowables)
        {
            foreach (var meowable in meowables)
            {
                meowable.meow();
            }
        }

        public static void meowsCare(IMeowable meowable)
        {
            meowable.meow();
        }
    }
}
