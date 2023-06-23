using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5_Generic_LINQ.Interfaces
{
    internal interface IMyQueue : IMyCollection
    {
        void Enqueue(object item);
        object Dequeue();
        object Peek();
        bool Contains(object item);

    }
}
