using HW_5_Generic_LINQ.Collections;
using HW_5_Generic_LINQ.ExtensionMethods;

namespace HW_5_Generic_LINQ
{
    internal class Program
    {
        static void Main()
        {

            var oList = new MyObservableList<int>();
            oList.ItemAdded += (a) => Console.WriteLine($"Added {a}");
            oList.ItemRemoved += (a) => Console.WriteLine($"Removed {a}");

            oList.Add(0);
            oList.Add(1);
            oList.Add(2);
            oList.Add(3);
            oList.Add(4);
            oList.Add(5);
            oList.Add(6);
            oList.Add(7);
            oList.Add(8);
            oList.Remove(0);

            foreach (var o in oList)
                Console.Write(o + " ");
            Console.WriteLine("\tobsList");

            IEnumerable<int> ol = oList.MyFilter(x => x > 6);
            foreach (var o in ol)
                Console.Write(o + " ");
            Console.WriteLine("\tMyFilter");

            IEnumerable<int> ol2 = oList.MySkip(3);
            foreach (var o in ol2)
                Console.Write(o + " ");
            Console.WriteLine( "\tMySkip" );

            IEnumerable<int> ol3 = oList.MySkipWhile(x => x <= 5);
            foreach (var o in ol3)
                Console.Write(o + " ");
            Console.WriteLine( "\tMySkipWhile" );

            IEnumerable<int> ol4 = oList.MyTake(3);
            foreach (var o in ol4)
                Console.Write(o + " ");
            Console.WriteLine( "\tMyTake" );

            IEnumerable<int> ol5 = oList.MyTakeWhile(x => x <= 5);
            foreach (var o in ol5)
                Console.Write(o + " ");
            Console.WriteLine( "\tMyTakeWhile" );

            IEnumerable<int> ol6 = oList.MySelect(x => x * x);
            foreach (var o in ol6)
                Console.Write(o + " ");
            Console.WriteLine( "\tMySelect" );

            //var priorityQueue = new PriorityQueue<string>();
            //priorityQueue.Enqueue("asf");
            //priorityQueue.Enqueue("456");
            //priorityQueue.Enqueue("eryy");
            //priorityQueue.Enqueue("qweqwr");
            //priorityQueue.Enqueue("47836");
            ////priorityQueue.Dequeue();

            //var pQ = priorityQueue.Filter(x => x == "34");
            //foreach (var p in pQ)
            //{
            //    Console.Write(p + " ");
            //}


            //var list = new Collections.List<int>();
            //list.Add(1); 
            //list.Add(2);
            //list.Add(8);
            //list.Add(9);
            //list.RemoveAt(3);
            //list.Add(3);
            //list.Add(4);
            //list.Add(5);
            //list.Add(11);
            //list.Add(12);
            //list.Add(6);
            //list.Add(7);
            //list.Add(10);
            //list.Add(13);

            //int a = list.Capacity;
            //list.Insert(0, 5);
            //list.Sort();
            //list.BinarySearch(a);
            //list.Insert(5, a);
            //list.BinarySearch(a);




            //foreach (int b in list)
            //{
            //    Console.Write(b + " ");
            //}
            //Console.WriteLine();
            //var linq = list.Filter(x => (int)x > 3);
            //foreach (int b in linq)
            //{
            //    Console.Write(b + " ");
            //}
            //Console.WriteLine();



            //var slist = new System.Collections.Generic.List<object>();
            //slist.BinarySearch()
            //slist.Where(x => x > 0);
            //slist.Skip;
            //slist.Take;
            //slist.First; //---no iterator;
            //slist.FirstOrDefault(4, ;   //--- no iterator;
            //slist.Last;                 //--- no iterator;
            //slist.SelectMany;
            //slist.All;                  //--- bool;
            //slist.Any()
            //slist.toarr;
            //slist.ToList;


            //List list = new List();
            //list.Add(1);
            //list.Add(2);
            //list.Add(3);
            //list.Add(4);
            //list.Add(5);
            //list.Add(4);
            //list.Add(7);

            ////list.Clear();
            //var fil = list.Filter(x => x.Equals(3));
            //var skip1 = list.Skip(4);
            //var skipWhile = list.SkipWhile(x => (int?)x < 4);
            //var take = list.Take(5);
            //var take2 = list.TakeWhile(x => (int?)x < 4);
            //var first = list.First(x => (int?)x == 14);
            //var first2 = list.FirstOrDefault(x => (int?)x == 12, "Default");
            //var last = list.Last(x => (int?) x == 3);
            //var last2 = list.LastOrDefault(x => (int?)x == 4, "Default");

            //var select = list.Select(x => (int)x * (int)x);
            //var all = list.All(x => (int?)x > 0);
            //var all2 = list.All(x => (int?)x < 8);
            //var any = list.Any(x => (int?)x < 0);
            //var any2 = list.Any(x => (int?)x == 5);
            //var arr = list.ToList();

            //foreach (var item in list)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            //foreach (var item in fil)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            //foreach (var item in skip1)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            //foreach (var item in skipWhile)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            //foreach (var item in take)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            //foreach (var item in take2)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            //foreach (var item in select)
            //{
            //    Console.Write(item + " ");
            //}


            //OneLinkedList list2 = new OneLinkedList();
            //list2.Add(8);
            //list2.Add(2);
            //list2.Add(6);
            //list2.Add(14);
            //list2.Add(5);
            //list2.Insert(3, 10);
            ////list2.Clear();
            //var fil2 = list2.Filter(x => x.Equals(3));
            //foreach (var item in list2)
            //{
            //    Console.WriteLine(item);
            //}
            //foreach (var item in fil2)
            //{
            //    Console.WriteLine(item);
            //}
            //list2.BinarySearch(18);



            //LinkedList list = new LinkedList();
            //list.Add(10);
            //list.Add(22);
            //list.Add(3);
            //list.Add(24);
            //list.Add(15);
            //list.Add(6);
            //list.Insert(2, 4);
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //list.BinarySearch(25);


            //Queue queue = new Queue();
            //queue.Enqueue(1);
            //queue.Enqueue(2);
            //queue.Enqueue(3);
            //queue.Enqueue(4);
            //queue.Enqueue(5);
            //foreach (var item in queue)
            //{
            //    Console.WriteLine(item);
            //}

            //Stack stack = new Stack();
            //stack.Push(1);
            //stack.Push(2);
            //stack.Push(3);
            //stack.Push(4);
            //stack.Push(5);
            //foreach (var item in stack)
            //{
            //    Console.WriteLine(item);
            //}

            //BinarySearchTree tree = new BinarySearchTree();
            //tree.Add(10);
            //tree.Add(11);
            //tree.Add(3);
            //tree.Add(4);
            //tree.Add(8);
            //tree.Add(50);
            //tree.Add(13);
            //tree.Add(12);
            //tree.Add(2);
            //tree.Add(15);
            //tree.Add(6);
            //tree.ToArray();


            //var fil2 = tree.Filter(x => x.Equals(3));
            //var skip2 = tree.Skip(10);
            //var skip3 = tree.SkipWhile(x => (int?)x < 11);
            //foreach (var item in tree)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            //foreach (var item in fil2)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            //foreach (var item in skip2)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            //foreach (var item in skip3)
            //{
            //    Console.Write(item + " ");
            //}


        }
    }
}