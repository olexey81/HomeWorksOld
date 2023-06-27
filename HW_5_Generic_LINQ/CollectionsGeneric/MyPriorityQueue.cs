using HW_5_Generic_LINQ.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace HomeWorks.HW_5_Generic_LINQ.CollectionsGeneric
{
    internal class MyPriorityQueue<T> : MyQueue<T> where T : IComparable<T>
    {
        public override void Enqueue(T item)
        {
            _items.Add(item);
            int position = Count - 1;

            while (position > 0 && _items[position].CompareTo(_items[position - 1]) > 0)
            {
                _items[position] = _items[position - 1];
                _items[position - 1] = item;
                position--;
            }
        }
    }
}
