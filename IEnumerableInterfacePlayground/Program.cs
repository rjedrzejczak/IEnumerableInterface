﻿using System;
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

            foreach (var a in array)
            {
                Console.WriteLine($"{a}");
            }

            var enumerator = array.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            
            var infiniteEnumerable = new MyInfiniteEnumerable();
            foreach (var VARIABLE in infiniteEnumerable)
            {
                Console.WriteLine(VARIABLE);

            }
        }
    }
    
    public class MyInfiniteEnumerable : IEnumerable<int>
    {
        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            return new MyInfiniteEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return new MyInfiniteEnumerator();
        }
    }

    public class MyInfiniteEnumerator() : IEnumerator<int>
    {
        object IEnumerator.Current => Current;
        public int Current { get; private set; } = 0;
        
        public bool MoveNext()
        {
            Current++;
            
            return true;
        }

        public void Reset()
        {
            Current = 0;
        }
        
        public void Dispose()
        {
            
        }
    }
}