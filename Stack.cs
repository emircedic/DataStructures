namespace DataStructures
{
    public class Stack
    {
        List<int> stack = new();

        public Stack() { }

        public void Push(int n)
        {
            stack.Add(n);
        }

        public int Pop()
        {
            if (Size() > 0)
            {
                int ele = (int)stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);
                return ele;
            }
            return -1;
        }

        public int Size()
        {
            return stack.Count;
        }
    }
}
