using System;
using System.Collections;
using System.Collections.Generic;

namespace IEnumerableInterfacePlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var array = new int[] {1, 2, 3};

            var enumerator = array.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            
            var infiniteEnumerable = new MyEnumerable();

            enumerator = infiniteEnumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            
            var dupa = new ArrayList();
        }
    }
    
    public class MyEnumerable : IEnumerable<int>
    {
        private int[] myData = new[] {4, 5, 6};

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(myData);
        }
        
        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            return new MyEnumerator(myData);
        }
    }

    public class MyEnumerator : IEnumerator<int>
    {
        private int[] values;
        private int index = -1;
        public int Current { get; private set; } = 0;
        
        public MyEnumerator(int[] myData)
        {
            values = myData;
        }
        object IEnumerator.Current => values[index];
        
        public bool MoveNext()
        {
            index++;
            
            return index < values.Length;
        }

        public void Reset()
        {
            index = 0;
        }
        
        public void Dispose()
        {
            
        }
    }
}