using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks.HW_5_Generic_LINQ.InterfacesObject
{
    public interface IMyStack : IMyCollection
    {
        object Peek();
        void Push(object item);
        object Pop();
        bool Contains(object item);
    }
}
