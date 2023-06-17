namespace HW_4_Collections
{
    internal class OneLinkedList
    {
        private OneLinkedNode? _first;
        private OneLinkedNode? _last;
        protected int _size;

        public int Count => _size; 
        public virtual object? First => _first?.Data;
        public virtual object? Last => _last?.Data;

        public virtual void Add(object data)
        {
            OneLinkedNode newNode = new OneLinkedNode(data);

            if (_first == null)
            {
                _first = newNode;
                _last = newNode;
            }
            else
            {
                _last.Next = newNode;        
                _last = newNode;             
            }

            _size++;
        }
        public virtual void AddFirst(object data)
        {
            OneLinkedNode newNode = new OneLinkedNode(data);

            if (_first == null)
            {
                _first = newNode;
                _last = newNode;
            }
            else
            {
                newNode.Next = _first;
                _first = newNode;
            }

            _size++;
        }

        public void Insert(uint index, object data)
        {
            if (index > _size)
                Console.WriteLine("Error! Incorrect index");

            if (index == 0)
            {
                AddFirst(data);
                return;
            }

            if (index == _size)
            {
                Add(data);
                return;
            }

            OneLinkedNode newNode = new OneLinkedNode(data);
            OneLinkedNode current = _first;
            OneLinkedNode previous = null;
            int currentIndex = 0;

            while (currentIndex < index)
            {
                previous = current;
                current = current.Next;
                currentIndex++;
            }

            newNode.Next = current;
            previous.Next = newNode;

            _size++;
        }

        public virtual void Clear()
        {
            _first = null;
            _last = null;
            _size = 0;
        }

        public virtual bool Contains(object data)
        {
            OneLinkedNode current = _first;

            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;

                current = current.Next;
            }

            return false;
        }

        public virtual object[] ToArray()
        {
            object[] array = new object[_size];
            OneLinkedNode current = _first;
            int index = 0;

            while (current != null)
            {
                array[index] = current.Data;
                current = current.Next;
                index++;
            }

            return array;
        }
        protected class OneLinkedNode
        {
            public object Data { get; }
            public OneLinkedNode? Next { get; set; } = null;

            public OneLinkedNode(object data)
            {
                Data = data;
            }
        }
    }
}
//  Однозв'язковий список.
//  Являє собою елементи, пов'язані один з одним через посилання на наступний елемент.
//  Список зберігає перший і останній елементи.

//  Методи:
//  + Add(object)
//  + AddFirst(object)
//  + Insert(int, object)(де int це индекс у який буде вставлення)
//  + Clear()
//  + bool Contains(object)
//  + object[] ToArray()

//  + Свойства Count, First, Last.