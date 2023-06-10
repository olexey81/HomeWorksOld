namespace HW_4_Collections
{
    internal class Program
    {
        static void Main()
        {
            List<int> list = new List<int>();   
            list.Add(1);

            List myList = new List(5);
            myList.Add(20);
            myList.Add("asd");
            myList.Add('w');
            myList.Add(453.6m);
            myList.Add(3.6m);
            myList.Add(20);
            myList.Add("asd");
            myList.Add('w');
            myList.Add(20);
            myList.Add("asd");
        }
    }

    struct List
    {
        private object[] _items;
        private const int _InitSize = 4;
        private uint _size;

        public List()
        {
            _items = new object[_InitSize];
        }
        public List(uint initSize)
        {
            _items = new object[initSize];
        }

        public void Add(object newItem)
        {

            if (_size < (uint)_items.Length)
                AddToEnd(newItem);
            else
            {
                uint _newSize = _size + _InitSize * 2;
                object[] _itemsExtend = new object[_newSize];

                for (int i = 0; i < _size; i++)
                    _itemsExtend[i] = _items[i];
                
                _items = _itemsExtend;

                AddToEnd(newItem);
            }

        }
        private void AddToEnd(object item)
        {
            _items[_size] = item;
            _size++;
        }

    }
}

// Список(List)
// Це динамічний масив, тобто. масив, який може змінювати свій розмір.
// Повинні бути методи:
//  Add(object)
//  Insert(int, object)
//  Remove(object)
//  RemoveAt(int)
//  Clear()
//  bool Contains(object)
//  int IndexOf(object)
//  object[] ToArray()
//  Reverse()

//  Також має бути властивість-індексатор (читання та запис) і властивість Count (тільки читання).
//  Додатково можна реалізувати якість Capacity. Тоді крім конструктора за замовчуванням, має бути конструктор, що приймає Capacity. (Не обов'язково)