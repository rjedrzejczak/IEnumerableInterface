using System;
using System.Collections;
using System.Collections.Generic;

namespace IEnumerableYeld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var test = new ValidateTestData();
            foreach (var VARIABLE in test)
            {
                foreach (var a in VARIABLE)
                {
                    Console.WriteLine(a);
                }
            }
        }
    }
    
    public class ValidateTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null, false };
            yield return new object[] { "", false };
            yield return new object[] { "* * * *", false };
            yield return new object[] { "* * * * * * *", false };
            yield return new object[] { "* * * * * L", false };
            yield return new object[] { "* * * * *", false };
            yield return new object[] { "* * * * * *", true };
            yield return new object[] { "* * *        * * *", true }; //many spaces
            yield return new object[] { "* * * * *	*", false }; //<tab>
            yield return new object[] { "0 5 21,22,23,19 * * *", true };
            yield return new object[] { "0 15 15 15 5 *", true }; //15 may at 15:15
            yield return new object[] { "15 15 15 15 5 *", true }; //15 may at 15:15:15
            yield return new object[] { "0 */2 1-2,4-5 * * *", true }; //every 2 minutes between 1:00-2:00 AM and 4:00-5:00 AM
            yield return new object[] { "*/2 */5 * * * *", true }; //every 2 seconds every 5 minutes
            yield return new object[] { "0 0 1 * * SUN", true }; //at 1:00 only in Sunday
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}