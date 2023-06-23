using HW_5_Generic_LINQ.Interfaces;
using System.Collections;

namespace HW_5_Generic_LINQ.Collections
{
    internal class MyLinkedList : MyOneLinkedList, IMyLinkedLists
    {
        private LinkedNode? _first;
        private LinkedNode? _last;
        public override object? First => _first?.Data;
        public override object? Last => _last?.Data;


        public override void Add(object data)
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
        public override void AddFirst(object data)
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
        public override int BinarySearch(object item)
        {
            Sort();
            int left = 0;
            int right = Count - 1;

            LinkedNode? current = _first;
            int index = 0;

            while (current != null)
            {
                if (Equals(current.Data, item))
                {
                    return index;
                }

                current = (LinkedNode)current.Next;
                index++;
            }

            return -1;
        }

        public override void Insert(int index, object data)
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

            LinkedNode newNode = new LinkedNode(data);
            LinkedNode current = _first;
            LinkedNode previous = null;
            int currentIndex = 0;

            while (currentIndex < index)
            {
                previous = current;
                current = (LinkedNode?)current.Next;
                currentIndex++;
            }

            newNode.Next = current;
            previous.Next = newNode;

            _size++;
        }
        public override void Remove(object data)
        {
            LinkedNode? current = _first;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current == _first)
                    {
                        _first = (LinkedNode?)current.Next;
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
                        ((LinkedNode)current.Next).Previous = (LinkedNode)current.Previous;
                    }

                    _size--;

                    break;
                }

                current = (LinkedNode?)current.Next;
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
                _first = (LinkedNode?)_first.Next;
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
        public override bool Contains(object data)
        {
            LinkedNode? current = _first;

            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;

                current = (LinkedNode?)current.Next;
            }

            return false;
        }

        public override void Sort()
        {
            _first = MergeSort(_first);
            UpdateLastNode();
        }
        private LinkedNode? MergeSort(LinkedNode? head)
        {
            if (head == null || head.Next == null)
            {
                return head;
            }

            LinkedNode? middle = GetMiddleNode(head);
            LinkedNode? nextToMiddle = (LinkedNode?)(middle?.Next);
            middle!.Next = null;

            LinkedNode? left = MergeSort(head);
            LinkedNode? right = MergeSort(nextToMiddle);

            return Merge(left, right);
        }
        private LinkedNode? Merge(LinkedNode? left, LinkedNode? right)
        {
            if (left == null)
            {
                return right;
            }

            if (right == null)
            {
                return left;
            }

            LinkedNode? result;
            int comparisonResult = Comparer<object>.Default.Compare(left.Data, right.Data);

            if (comparisonResult <= 0)
            {
                result = left;
                result.Next = Merge((LinkedNode?)left.Next, right);
            }
            else
            {
                result = right;
                result.Next = Merge(left, (LinkedNode?)right.Next);
            }

            return result;
        }
        private LinkedNode? GetMiddleNode(LinkedNode? head)
        {
            if (head == null)
            {
                return head;
            }

            LinkedNode? slowPointer = head;
            LinkedNode? fastPointer = head;

            while ((LinkedNode?)(fastPointer?.Next) != null && fastPointer.Next.Next != null)
            {
                slowPointer = (LinkedNode?)(slowPointer?.Next);
                fastPointer = (LinkedNode)fastPointer.Next.Next;
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

            LinkedNode current = _first;
            while (current.Next != null)
            {
                current = (LinkedNode)current.Next;
            }

            _last = current;
        }

        public override object[] ToArray()
        {
            object[] array = new object[_size];
            LinkedNode current = _first;
            int index = 0;

            while (current != null)
            {
                array[index] = current.Data;
                current = (LinkedNode?)current.Next;
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
        public override IEnumerator GetEnumerator()
        {
            base._first = _first;
            return base.GetEnumerator();
        }
        private class LinkedNode : OneLinkedNode
        {
            public LinkedNode? Previous { get; set; } = null;

            public LinkedNode(object data) : base(data)
            {
            }
        }
    }
}
