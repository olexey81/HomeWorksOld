using HW_5_Generic_LINQ.Interfaces;
using System.Collections;

namespace HW_5_Generic_LINQ.Collections
{
    internal class MyLinkedList<T> : MyOneLinkedList<T> where T : IComparable<T>
    {
        private LinkedNode<T> _first;
        private LinkedNode<T> _last;
        public override T First => _first.Data;
        public override T Last => _last.Data;

        public override void Add(T data)
        {
            LinkedNode<T> newNode = new LinkedNode<T>(data);

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
        public override void AddFirst(T data)
        {
            LinkedNode<T> newNode = new LinkedNode<T>(data);

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

        public override int BinarySearch(T item) 
        {
            Sort();
            int left = 0;
            int right = Count - 1;

            LinkedNode<T> current = _first;
            int index = 0;

            while (current != null)
            {
                if (Equals(current.Data, item))
                {
                    return index;
                }

                current = (LinkedNode<T>)current.Next;
                index++;
            }

            return -1;
        }
        public override void Insert(int index, T data)
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

            LinkedNode<T> newNode = new LinkedNode<T>(data);
            LinkedNode<T> current = _first;
            LinkedNode<T> previous = null;
            int currentIndex = 0;

            while (currentIndex < index)
            {
                previous = current;
                current = (LinkedNode<T>)current.Next;
                currentIndex++;
            }

            newNode.Next = current;
            previous.Next = newNode;

            _size++;
        }
        public override void Remove(T data)
        {
            LinkedNode<T> current = _first;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current == _first)
                    {
                        _first = (LinkedNode<T>)current.Next;
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
                        ((LinkedNode<T>)current.Next).Previous = current.Previous;
                    }

                    _size--;

                    break;
                }

                current = (LinkedNode<T>)current.Next;
            }
        }
        public override void RemoveFirst()
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
                _first = (LinkedNode<T>)_first.Next;
                _first.Previous = null;
            }

            _size--;
        }
        public override void RemoveLast()
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

        public override void Sort()
        {
            _first = MergeSort(_first);
            UpdateLastNode();
        }
        private LinkedNode<T> MergeSort(LinkedNode<T> head) 
        {
            if (head == null || head.Next == null)
            {
                return head;
            }

            LinkedNode<T> middle = GetMiddleNode(head);
            LinkedNode<T> nextToMiddle = (LinkedNode<T>)middle?.Next;
            middle!.Next = null;

            LinkedNode<T> left = MergeSort(head);
            LinkedNode<T> right = MergeSort(nextToMiddle);

            return Merge(left, right);
        }
        private LinkedNode<T> Merge(LinkedNode<T> left, LinkedNode<T> right) 
        {
            if (left == null)
            {
                return right;
            }

            if (right == null)
            {
                return left;
            }

            LinkedNode<T> result;
            int comparisonResult = Comparer<T>.Default.Compare((T)Convert.ChangeType(left.Data, typeof(T)), (T)Convert.ChangeType(right.Data, typeof(T)));

            if (comparisonResult <= 0)
            {
                result = left;
                result.Next = Merge((LinkedNode<T>)left.Next, right);
            }
            else
            {
                result = right;
                result.Next = Merge(left, (LinkedNode<T>)right.Next);
            }

            return result;
        }
        private LinkedNode<T> GetMiddleNode(LinkedNode<T> head)
        {
            if (head == null)
            {
                return head;
            }

            LinkedNode<T> slowPointer = head;
            LinkedNode<T> fastPointer = head;

            while (fastPointer?.Next != null && fastPointer.Next.Next != null)
            {
                slowPointer = (MyLinkedList<T>.LinkedNode<T>)(slowPointer?.Next);
                fastPointer = (MyLinkedList<T>.LinkedNode<T>)fastPointer.Next.Next;
            }

            return slowPointer;
        }
        private void UpdateLastNode()
        {
            if (_first == null)
            {
                _last = null;
                return;
            }

            LinkedNode<T> current = _first;
            while (current.Next != null)
            {
                current = (MyLinkedList<T>.LinkedNode<T>)current.Next;
            }

            _last = current;
        }


        public override bool Contains(T data)
        {
            LinkedNode<T> current = _first;

            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;

                current = (LinkedNode<T>)current.Next;
            }

            return false;
        }
        public override T[] ToArray()
        {
            T[] array = new T[_size];
            LinkedNode<T> current = _first;
            int index = 0;

            while (current != null)
            {
                array[index] = current.Data;
                current = (LinkedNode<T>)current.Next;
                index++;
            }

            return array;
        }
        public override void Clear()
        {
            _first = null;
            _last = null;
            _size = 0;
        }
        public override IEnumerator<T> GetEnumerator()
        {
            base._first = _first;
            return base.GetEnumerator();
        }
        private class LinkedNode<T> : OneLinkedNode<T>
        {
            public LinkedNode<T> Previous { get; set; } = null;

            public LinkedNode(T data) : base(data)
            {
            }
        }
    }
}
