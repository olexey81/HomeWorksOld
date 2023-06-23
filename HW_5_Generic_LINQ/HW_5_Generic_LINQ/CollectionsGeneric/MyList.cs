using System.Collections;

namespace HW_5_Generic_LINQ.Collections
{
    internal class MyList<T> : Interfaces.IMyList<T> 
    {
        private T?[] _items;
        private const int _InitCapacity = 4;
        private int _size;

        public int Count => _size;
        public int Capacity
        {
            get => _items.Length;
            set
            {
                if (value < _size)
                    Console.WriteLine("Error! Capacity cannot be less than elements number");
                else
                {
                    T[] _itemsExtend = new T[value];

                    for (int i = 0; i < _size; i++)
                        _itemsExtend[i] = _items[i];

                    _items = _itemsExtend;
                }
            }
        }
        public T this[int index]
        {
            get
            {
                if (index < Count)
                    return _items[index];
                else
                {
                    Console.WriteLine("Error! Incorrect index");
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index < Count)
                    _items[index] = value;
                else
                    Console.WriteLine("Error! Incorrect index");
            }
        }


        public MyList()
        {
            _items = new T[_InitCapacity];
        }
        public MyList(int capacity)
        {
            Capacity = capacity;
            _items = new T[Capacity];
        }

        public virtual void Add(T newItem)
        {
            if (_size < _items.Length)
                AddToEnd(newItem);
            else
            {
                Grow();
                AddToEnd(newItem);
            }
        }

        public int BinarySearch(T item) => BinarySearch(item, 0, Count - 1);
        private int BinarySearch(T item, int left, int right)
        {
            Sort();

            if (left <= right)
            {
                int middle = (left + right) / 2;
                int comparisonResult = Comparer<T>.Default.Compare(_items[middle], item);

                if (comparisonResult == 0)
                {
                    return middle;
                }
                else if (comparisonResult > 0)
                {
                    return BinarySearch(item, left, middle - 1);
                }
                else
                {
                    return BinarySearch(item, middle + 1, right);
                }
            }

            return -1; 
        }

        public void Insert(int index, T newItem)
        {
            if (index > _size)
            {
                Console.WriteLine("Error! Index is out of array's size");
                return;
            }

            ModArrayToInsert(index);
            _items[index] = newItem;
            _size++;
        }
        public virtual bool Remove(T itemToRemove)
        {
            if (Contains(itemToRemove))
            {
                CompressArray(IndexOf(itemToRemove));
                return true;
            }
            else
                return false;
        }
        public void RemoveAt(int indexToRemove)
        {
            if (indexToRemove >= _size)
            {
                Console.WriteLine("Error! Index is out of array's size");
                return;
            }
            else
                CompressArray(indexToRemove);
        }
        public void Clear()
        {
            _items = new T[_InitCapacity];
            _size = 0;
        }
        public bool Contains(T item)
        {
            if (IndexOf(item) > -1)
                return true;
            return false;
        }
        public int IndexOf(T item)
        {
            int indexItem = -1;

            for (int i = 0; i < _size; i++)
            {
                if (_items[i].Equals(item))
                {
                    indexItem = i;
                    break;
                }
            }

            return indexItem;
        }
        public void Reverse()
        {
            T[] reversedItems = new T[Capacity];

            for (int i = 0; i < _size; i++)
                reversedItems[i] = _items[_size - 1 - i];

            _items = reversedItems;
        }
        public T Search(T item)
        {

            return item;
        }

        public void Sort() => MergeSort(_items, 0, Count - 1);
        private void MergeSort(T[] arr, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSort(arr, left, middle);
                MergeSort(arr, middle + 1, right);

                Merge(arr, left, middle, right);
            }
        }
        private void Merge(T[] arr, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            T[] leftArr = new T[n1];
            T[] rightArr = new T[n2];

            Array.Copy(arr, left, leftArr, 0, n1);
            Array.Copy(arr, middle + 1, rightArr, 0, n2);

            int i = 0, j = 0;
            int k = left;

            while (i < n1 && j < n2)
            {
                if (Comparer<T>.Default.Compare(leftArr[i], rightArr[j]) <= 0)
                {
                    arr[k] = leftArr[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArr[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = leftArr[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = rightArr[j];
                j++;
                k++;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[_size];

            for (int i = 0; i < _size; i++)
                array[i] = _items[i];

            return array;

        }

        private void AddToEnd(T newItem) => _items[_size++] = newItem;

        private void Grow()
        {
            T[] _itemsExtend = new T[_InitCapacity + _items.Length * 2];

            for (int i = 0; i < _size; i++)
                _itemsExtend[i] = _items[i];

            _items = _itemsExtend;
        }
        private void ModArrayToInsert(int index)
        {
            if (_size == Capacity)
            {
                T[] _itemsMod;
                _itemsMod = new T[Capacity + _InitCapacity];
                for (int i = 0; i < _size; i++)
                {
                    if (i < index)
                        _itemsMod[i] = _items[i];
                    else
                        _itemsMod[i + 1] = _items[i];
                }
                _items = _itemsMod;
            }
            else
                for (int i = _size; i > index; i--)
                    _items[i] = _items[i - 1];
        }
        private void CompressArray(int index)
        {
            
            for (int i = index; i < _size; i++)
            {
                if (index == _size - 1)
                {
                    _items[index] = default;
                    _size--;
                    return;
                }
                _items[i] = _items[i + 1];
            }
                
            _size--;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        //public IEnumerator<T> GetEnumerator()
        //{
        //    for (int i = 0; i < Count; i++)
        //        yield return _items[i];
        //}

        public IEnumerator<T> GetEnumerator() => new Iterator<T>(this);
        private class Iterator<T> : IEnumerator<T>
        {
            private readonly MyList<T> _items;
            private int _index;
            public T Current { get; private set; }
            object IEnumerator.Current => Current;

            public Iterator(MyList<T> items)
            {
                _items = items;
                _index = 0;
            }
            public bool MoveNext()
            {
                if (_index < _items.Count)
                {
                    Current = _items[_index++];
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                _index = 0;
            }

            public void Dispose()
            {
            }
        }
    }
}
