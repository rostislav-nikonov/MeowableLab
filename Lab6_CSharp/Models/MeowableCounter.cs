using System;

namespace Lab6_CSharp.Models
{
    internal class MeowableCounter : IMeowable
    {
        private IMeowable _meowable;
        private int _meowCount;

        public MeowableCounter(IMeowable meowable)
        {
            _meowable = meowable;
            _meowCount = 0;
        }

        public void meow()
        {
            _meowable.meow();
            _meowCount++;
        }

        public int MeowCount
        {
            get 
            { 
                return _meowCount; 
            }
        }

        public void Reset()
        {
            _meowCount = 0;
        }
    }
}
