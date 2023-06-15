namespace HW_4_Collections
{
    internal class List
    {
        private object[] _items;
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
                    object[] _itemsExtend = new object[value];

                    for (int i = 0; i < _size; i++)
                        _itemsExtend[i] = _items[i];

                    _items = _itemsExtend;
                }
            }
        }
        public object this[int index]
        {
            get
            {
                if (index <= _size - 1)
                    return _items[index];
                else
                {
                    Console.WriteLine("Error! Incorrect index");
                    return null;
                }
            }
            set
            {
                if (index < _size - 1)
                    _items[index] = value;
                else
                    Console.WriteLine("Error! Incorrect index");
            }

        }


        public List()
        {
            _items = new object[_InitCapacity];
        }
        public List(int capacity)
        {
            Capacity = capacity;
            _items = new object[Capacity];
        }

        public void Add(object newItem)
        {
            if (_size < _items.Length)
                AddToEnd(newItem);
            else
            {
                ExtendArray();
                AddToEnd(newItem);
            }
        }
        public void Insert(int index, object newItem)
        {
            if (index >= _size)
            {
                Console.WriteLine("Error! Index is out of array's size");
                //throw new ArgumentOutOfRangeException(nameof(index));
                return;
            }

            ModArrayToInsert(index);
            _items[index] = newItem;
            _size++;
        }
        public bool Remove(object itemToRemove)
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
            _items = new object[_InitCapacity];
            _size = 0;
        }
        public bool Contains(object item)
        {
            if (IndexOf(item) > -1)
                return true;
            return false;
        }
        public int IndexOf(object item)
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
        public object[] ToArray()
        {
            object[] array = new object[_size];

            for (int i = 0; i < _size; i++)
                array[i] = _items[i];

            return array;

        }
        public void Reverse()
        {
            object[] reversedItems = new object[Capacity];

            for (int i = 0; i < _size; i++)
                reversedItems[i] = _items[_size - 1 - i];

            _items = reversedItems;
        }



        private void AddToEnd(object newItem)
        {
            _items[_size] = newItem;
            _size++;
        }

        private void ExtendArray()
        {
            object[] _itemsExtend = new object[Capacity + _InitCapacity * 2];

            for (int i = 0; i < _size; i++)
                _itemsExtend[i] = _items[i];

            _items = _itemsExtend;
        }
        private void ModArrayToInsert(int index)
        {
            if (_size == Capacity)
            {
                object[] _itemsMod;
                _itemsMod = new object[Capacity + _InitCapacity];
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
                    _items[i] = _items[i + 1];
            _size--;
        }
    }
}

// Список(List)
// Це динамічний масив, тобто. масив, який може змінювати свій розмір.
// Повинні бути методи:
//  Add(object)             +
//  Insert(int, object)     +
//  Remove(object)          +
//  RemoveAt(int)           +
//  Clear()                 +
//  bool Contains(object)   +
//  int IndexOf(object)     +
//  object[] ToArray()      +
//  Reverse()               +

//  Також має бути властивість-індексатор (читання та запис) і властивість Count (тільки читання). +
//  Додатково можна реалізувати якість Capacity. Тоді крім конструктора за замовчуванням, має бути конструктор, що приймає Capacity. (Не обов'язково) +