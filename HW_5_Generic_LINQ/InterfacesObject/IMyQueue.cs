using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks.HW_5_Generic_LINQ.InterfacesObject
{
    public interface IMyQueue : IMyCollection
    {
        void Enqueue(object item);
        object Dequeue();
        object Peek();
        bool Contains(object item);

    }
}
