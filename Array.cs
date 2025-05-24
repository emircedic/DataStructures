namespace DataStructures.asdf
{
    public class StaticArray
    {
        // Insert n into arr at the next open position.
        // Length is the number of 'real' values in arr, and capacity
        // is the size (aka memory allocated for the fixed size array).
        public void InsertEnd(int[] arr, int n, int length, int capacity)
        {
            if (length < capacity)
            {
                arr[length] = n;
            }
        }

        // Remove from the last position in the array if the array
        // is not empty (i.e. length is non-zero).
        public void RemoveEnd(int[] arr, int length)
        {
            if (length > 0)
            {
                // Overwrite last element with some default value.
                // We would also consider the length to be decreased by 1.
                arr[length - 1] = 0;
                length--;
            }
        }

        // Insert n into index i after shifting elements to the right.
        // Assuming i is a valid index and arr is not full.
        public void InsertMiddle(int[] arr, int i, int n, int length)
        {
            // Shift starting from the end to i.
            for (int index = length - 1; index > i - 1; index--)
            {
                arr[index + 1] = arr[index];
            }
            // Insert at i
            arr[i] = n;
        }

        // Remove value at index i before shifting elements to the left.
        // Assuming i is a valid index.
        public void RemoveMiddle(int[] arr, int i, int length)
        {
            // Shift starting from i + 1 to end.
            for (int index = i + 1; index < length; index++)
            {
                arr[index - 1] = arr[index];
            }
            // No need to 'remove' arr[i], since we already shifted
        }

        public void PrintArr(int[] arr, int length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }


    public class DynamicArray
    {
        int capacity;
        int length;
        int[] arr;

        public DynamicArray()
        {
            capacity = 2;
            length = 0;
            arr = new int[2];
        }

        // Insert n in the last position of the array
        public void PushBack(int n)
        {
            if (length == capacity)
            {
                this.Resize();
            }

            // insert at next empty position
            arr[length] = n;
            length++;
        }

        public void Resize()
        {
            // Create new array of double capacity
            capacity = 2 * capacity;
            int[] newArr = new int[capacity];

            // Copy elements to newArr
            for (int i = 0; i < length; i++)
            {
                newArr[i] = arr[i];
            }
            arr = newArr;
        }

        // Remove the last element in the array
        public void PopBack()
        {
            if (length > 0)
            {
                length--;
            }
        }

        // Get value at i-th index
        public int Get(int i)
        {
            if (i < length)
            {
                return arr[i];
            }
            // Here we would throw an out of bounds exception
            return -1;
        }

        // Insert n at i-th index
        public void Insert(int i, int n)
        {
            if (i < length)
            {
                arr[i] = n;
                return;
            }
            // Here we would throw an out of bounds exception  
            return;
        }

        public void Print()
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
