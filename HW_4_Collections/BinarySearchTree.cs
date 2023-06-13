namespace HW_4_Collections
{
    public class BinarySearchTree
    {
        private Node _root;
        private int _size;

        public Node Root => _root;
        public int Count => _size;

        public void Add(int value)
        {
            _root = InsertNode(_root, value);
            _size++;
        }

        private Node InsertNode(Node current, int value)
        {
            if (current == null)
                return new Node(value);

            if (value <= current.Value)                                 // якщо однакове - у ліву гілку
                current.Left = InsertNode(current.Left, value);
            else if (value > current.Value)
                current.Right = InsertNode(current.Right, value);

            return current;
        }

        public bool Contains(int value) => SearchNode(_root, value) != null;
        
        private Node SearchNode(Node current, int value)
        {
            if (current == null || current.Value == value)
                return current;

            if (value <= current.Value)
                return SearchNode(current.Left, value);
            else
                return SearchNode(current.Right, value);
        }

        public void Clear()
        {
            _root = null;
            _size = 0;
        }

        public object[] ToArray()
        {
            List array = new List(_size);
            TreeInOrder(_root, array);

            return array.ToArray();
        }

        private void TreeInOrder(Node current, List result)
        {
            if (current != null)
            {
                TreeInOrder(current.Left, result);

                result.Add(current.Value);

                TreeInOrder(current.Right, result);
            }
        }

        public class Node
        {
            public int Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }
    }

}
//  Дерево
//  Потрібно реалізувати бінарне дерево пошуку: де кожен вузол може містити ліві та праві вузли – зліва найменші елементи, а праворуч – найбільші.
//  Обхід по дереву має бути рекурсивним.
//  Свойства: Root и Count

//  Методы:
//  Add(int)                +
//  bool Contains(int)      +
//  Clear()                 +
//  ToArray().              +

//  Додатково, на свій страх і ризик: створення дерева, що самобалансується, або методу балансування. (Див. AVL-дерево, червоно-чорне дерево).
