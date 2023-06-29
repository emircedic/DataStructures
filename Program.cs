// See https://aka.ms/new-console-template for more information
using DataStructures;

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

var bracketStack = new BracketStack();

bracketStack.Push("[");
bracketStack.Push("{");
bracketStack.Push("}");
bracketStack.Push("(");
bracketStack.Push("[");
bracketStack.Push("]");

var customStack = new CustomStack<string>();
customStack.Push("[");
customStack.Push("{");
customStack.Push("}");
customStack.Push(")");
customStack.Push("[");
customStack.Push("]");

var lastItem = customStack.Pop();

var peekLastItem = customStack.Peek();
#endregion

Console.WriteLine("Hello world!");


