namespace HW_4_Collections
{
    internal class LinkedList : OneLinkedList
    {
        private LinkedNode _first;
        private LinkedNode _last;
        public override object First => _first.Data;
        public override object Last => _last.Data;


        public new void Add(object data)
        {
            LinkedNode newNode = new LinkedNode(data);

            if (_first == null)
            {
                _first = newNode;
                _last = newNode;
            }
            else
            {
                newNode.Previous = _last;
                _last.Next = newNode;
                _last = newNode;
            }

            _size++;
        }

        public new void AddFirst(object data)
        {
            LinkedNode newNode = new LinkedNode(data);

            if (_first == null)
            {
                _first = newNode;
                _last = newNode;
            }
            else
            {
                newNode.Next = _first;
                _first.Previous = newNode;
                _first = newNode;
            }

            _size++;
        }

        public void Remove(object data)
        {
            LinkedNode current = _first;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current == _first)
                    {
                        _first = current.Next;
                        if (_first != null)
                            _first.Previous = null;
                    }
                    else if (current == _last)
                    {
                        _last = current.Previous;
                        if (_last != null)
                            _last.Next = null;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }

                    _size--;

                    break;
                }

                current = current.Next;
            }
        }

        public void RemoveFirst()
        {
            if (_first == null)
                return;

            if (_first == _last)
            {
                _first = null;
                _last = null;
            }
            else
            {
                _first = _first.Next;
                _first.Previous = null;
            }

            _size--;
        }

        public void RemoveLast()
        {
            if (_last == null)
                return;

            if (_first == _last)
            {
                _first = null;
                _last = null;
            }
            else
            {
                _last = _last.Previous;
                _last.Next = null;
            }

            _size--;
        }

        public new bool Contains(object data)
        {
            LinkedNode current = _first;

            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;

                current = current.Next;
            }

            return false;
        }

        public new object[] ToArray()
        {
            object[] array = new object[_size];
            LinkedNode current = _first;
            int index = 0;

            while (current != null)
            {
                array[index] = current.Data;
                current = current.Next;
                index++;
            }

            return array;
        }

        public new void Clear() 
        {
            _first = null;
            _last = null;
            _size = 0;
        }

        private class LinkedNode : OneLinkedNode
        {
            public new LinkedNode Next { get; set; } = null;
            public LinkedNode Previous { get; set; } = null;

            public LinkedNode(object data) : base(data)
            {
            }
        }
    }
}
//  Двозв'язковий список.
//  Являє собою елементи, пов'язані один з одним через посилання на наступний і попередній елементи.
//  Сам список зберігає перший та останній елементи.

//  Методи
//  + Add(object),
//  + AddFirst(object),
//  + Remove(object),
//  + RemoveFirst(),
//  + RemoveLast(),
//  + bool Contains(object),
//  + ToArray(),
//  + Clear()
//  + Властивості – Count, First, Last – тільки для читання.