namespace DataStructures
{     
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

        public void RemoveAt(int index)
        {
            for (int i = index; i < length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }

            length--;
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
