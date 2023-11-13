// See https://aka.ms/new-console-template for more information
using DataStructures;
using DataStructures.AVL;

#region Dynamic Array

//var dynamicArray = new DynamicArray<int>();
//dynamicArray.Add(0);
//dynamicArray.Add(1);
//dynamicArray.Add(2);
//dynamicArray.Add(3);
//dynamicArray.Add(4);
//dynamicArray.Add(5);
//dynamicArray.Add(6);


//foreach (var item in dynamicArray)
//{
//    Console.WriteLine(item);
//}

//var stringResult = dynamicArray.ToString();

//dynamicArray.RemoveAt(2);
//dynamicArray.Remove(3);
//var contains = dynamicArray.Contains(4);
//var index = dynamicArray.IndexOf(1);
//dynamicArray.Clear();

#endregion

#region Doubly Linked List

//var doublyLinkedList = new DoublyLinkedList<int>();
//doublyLinkedList.Add(0);
//doublyLinkedList.Add(1);
//doublyLinkedList.Add(2);
//doublyLinkedList.Add(3);
//doublyLinkedList.Add(4);

//doublyLinkedList.AddFirst(5);

//var peekFirst = doublyLinkedList.PeekFirst();

//var peekLast = doublyLinkedList.PeekLast();

//var removeFirst = doublyLinkedList.RemoveFirst();

//var removeLast = doublyLinkedList.RemoveLast();

//var remove = doublyLinkedList.Remove(doublyLinkedList.Head.Next.Next);

//var removeAt = doublyLinkedList.RemoveAt(3);

//var removeValue= doublyLinkedList.Remove(4);

//var indexOf = doublyLinkedList.IndexOf(3);

//var contains = doublyLinkedList.Contains(2);

#endregion

#region Stack

//var bracketStack = new BracketStack();

//bracketStack.Push("[");
//bracketStack.Push("{");
//bracketStack.Push("}");
//bracketStack.Push("(");
//bracketStack.Push("[");
//bracketStack.Push("]");

//var customStack = new CustomStack<string>();
//customStack.Push("[");
//customStack.Push("{");
//customStack.Push("}");
//customStack.Push(")");
//customStack.Push("[");
//customStack.Push("]");

//var lastItem = customStack.Pop();

//var peekLastItem = customStack.Peek();

#endregion

#region Queue

//var queue = new CustomQueue<int>();

//queue.Enqueue(1);
//queue.Enqueue(2);
//queue.Enqueue(3);
//queue.Enqueue(4);
//queue.Enqueue(5);

//queue.Dequeue();

//var peekFirst = queue.Peek();

#endregion

#region Priority Queues

//var priorityQueue = new PriorityQueue<int>(new List<int>() { 22, 6, 20, 5, 3, 26, 1, 27, 30, 35, 26, 66, 24 });
//var isMinHeapVariant = priorityQueue.CheckMinHeapVariant(0);

//var item = priorityQueue.Poll();
//isMinHeapVariant = priorityQueue.CheckMinHeapVariant(0);

//item = priorityQueue.Peek();

//priorityQueue.Add(2);
//isMinHeapVariant = priorityQueue.CheckMinHeapVariant(0);

#endregion

#region Union Find

//var unionFind = new UnionFind(7);

//unionFind.Unify(0, 1);
//unionFind.Unify(2, 3);
//unionFind.Unify(4, 5);

//var zeroAndOneConnection = unionFind.AreConnected(0, 1);
//var twoAndThreeConnection = unionFind.AreConnected(2, 3);
//var fourAndFiveConnection = unionFind.AreConnected(4, 5);

//unionFind.Unify(1, 2);
//unionFind.Unify(4, 0);

//var root = unionFind.Find(3);
//var componentSize = unionFind.GetComponentSize(5);

//var elementSize = unionFind.GetElementCount();
//var components = unionFind.GetComponentCount();

#endregion

#region Binary Search Tree

//var binarySearchTree = new BinarySearchTree();

//var isEmpty = binarySearchTree.IsEmpty();
//var size = binarySearchTree.GetSize();

//binarySearchTree.Add(10);
//binarySearchTree.Add(20);
//binarySearchTree.Add(30);
//binarySearchTree.Add(25);
//binarySearchTree.Add(5);

//size = binarySearchTree.GetSize();
//isEmpty = binarySearchTree.IsEmpty();

//var nodeExists = binarySearchTree.Contains(10);
//var removedNode = binarySearchTree.Remove(10);
//nodeExists = binarySearchTree.Contains(10);

//var height = binarySearchTree.GetHeight();

#endregion

#region Hash Table Seperate Chaining

//var hashTableSeperateChaining = new HashTableSeperateChaining<int, string>(10);

//var isEmpty = hashTableSeperateChaining.IsEmpty();
//var size = hashTableSeperateChaining.Size();

//hashTableSeperateChaining.Insert(1, "One");
//hashTableSeperateChaining.Insert(2, "Two");
//hashTableSeperateChaining.Insert(3, "Three");
//hashTableSeperateChaining.Insert(4, "Four");
//hashTableSeperateChaining.Insert(5, "Five");

//var containsOne = hashTableSeperateChaining.ContainsKey(1);
//var getOne = hashTableSeperateChaining.Get(1);
//var removeOne = hashTableSeperateChaining.Remove(1);

//isEmpty = hashTableSeperateChaining.IsEmpty();
//size = hashTableSeperateChaining.Size();

//hashTableSeperateChaining.Insert(1, "One");
//var newGetOne = hashTableSeperateChaining.Get(1);

//isEmpty = hashTableSeperateChaining.IsEmpty();
//size = hashTableSeperateChaining.Size();

//hashTableSeperateChaining.Clear();

//isEmpty = hashTableSeperateChaining.IsEmpty();
//size = hashTableSeperateChaining.Size();

#endregion

#region Hash Table Quadratic Probing

//var hashTableQuadraticProbing = new HashTableQuadraticProbing();

//var isEmpty = hashTableQuadraticProbing.IsEmpty();
//var size = hashTableQuadraticProbing.Size();

//hashTableQuadraticProbing.Add(1, "One");
//hashTableQuadraticProbing.Add(2, "Two");
//hashTableQuadraticProbing.Add(3, "Three");

//isEmpty = hashTableQuadraticProbing.IsEmpty();
//size = hashTableQuadraticProbing.Size();

//var containsOne = hashTableQuadraticProbing.ContainsKey(1);

//var getOne = hashTableQuadraticProbing.Get(1);
//var capacity = hashTableQuadraticProbing.GetCapacity();

//hashTableQuadraticProbing.Add(4, "Four");
//hashTableQuadraticProbing.Add(5, "Five");
//hashTableQuadraticProbing.Add(6, "Six");

//capacity = hashTableQuadraticProbing.GetCapacity();

//var keys = hashTableQuadraticProbing.GetKeys();
//var values = hashTableQuadraticProbing.GetValues();

//var hasOne = hashTableQuadraticProbing.HasKey(1);

//var removeOne = hashTableQuadraticProbing.Remove(1);

//isEmpty = hashTableQuadraticProbing.IsEmpty();
//size = hashTableQuadraticProbing.Size();

//hashTableQuadraticProbing.Clear();

//isEmpty = hashTableQuadraticProbing.IsEmpty();
//size = hashTableQuadraticProbing.Size();

#endregion

#region Fenwick Tree

//var valuesForFenwickTree = new long[] { 0, 1, 2, 2, 4 };
//var fenwickTree = new FenwickTree(valuesForFenwickTree);

//var getSum = fenwickTree.Sum(1, 4);

//fenwickTree.Sum(1, 4);
//fenwickTree.Add(3, 1);

//getSum = fenwickTree.Sum(1, 4);
//fenwickTree.Set(4, 0);

//getSum = fenwickTree.Sum(1, 4);
//var getTwo = fenwickTree.Get(2);

#endregion

#region AVL Tree

// a, b, c, d, e, f, g

//var avlTree = new AVLTree();
//var insertA = avlTree.Insert("a");
//var insertB = avlTree.Insert("b");
//var insertC = avlTree.Insert("c");
//var insertD = avlTree.Insert("d");
//var insertE = avlTree.Insert("e");
//var insertF = avlTree.Insert("f");
//var insertG = avlTree.Insert("g");

//var size = avlTree.Size();
//var containsF = avlTree.Contains("f");
//var remove = avlTree.Remove("f");
//containsF = avlTree.Contains("f");

//var isEmpty = avlTree.IsEmpty();
//var height = avlTree.GetHeight();
//size = avlTree.Size();

#endregion

Console.WriteLine("Hello world!");


