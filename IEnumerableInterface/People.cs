using System;
using System.Collections;

namespace IEnumerableInterface
{
    public class People : IEnumerable
    {
        private Person[] _people;
        
        public People(Person[] pArray)
        {
            _people = new Person[pArray.Length];

            for (int i = 0; i < pArray.Length; i++)
            {
                _people[i] = pArray[i];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new PeopleEnum(_people);
        }
    }
}