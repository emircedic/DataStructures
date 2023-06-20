// See https://aka.ms/new-console-template for more information
using DataStructures;

Console.WriteLine("Hello, World!");

#region Dynamic Array

var dynamicArray = new DynamicArray<int>();
dynamicArray.Add(0);
dynamicArray.Add(1);
dynamicArray.Add(2);
dynamicArray.Add(3);
dynamicArray.Add(4);
dynamicArray.Add(5);
dynamicArray.Add(6);


foreach (var item in dynamicArray)
{
    Console.WriteLine(item);
}

var stringResult = dynamicArray.ToString();

dynamicArray.RemoveAt(2);
dynamicArray.Remove(3);
var contains = dynamicArray.Contains(4);
var index = dynamicArray.IndexOf(1);
dynamicArray.Clear();

#endregion

Console.WriteLine("Hello, World!");
