namespace DataStructures
{
    public class CustomStack<T>
    {
        private List<T> values = new();

        public int Size()
        {
            return values.Count;
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public void Push(T item)
        {
            values.Add(item);
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var value = values.Last();
            values.RemoveAt(Size() - 1);
            return value;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return values[0];
        }
    }


    public class BracketStack
    {
        private List<string> stack = new List<string>();
        private Dictionary<string, string> bracketTypes = new Dictionary<string, string>()
    {
        { "]", "[" },
        { "}", "{" },
        { ")", "(" }
    };

        public void Push(string input)
        {
            if (bracketTypes.Values.Contains(input))
            {
                stack = stack.Prepend(input).ToList();
            }
            else
            {
                var openingBracket = bracketTypes[input];

                if (Peek() == openingBracket)
                    Pop();
                else
                    throw new InvalidOperationException();
            }

        }

        public string Pop()
        {
            if (stack.Any())
            {
                var value = stack[0];
                stack.RemoveAt(0);
                return value;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public string Peek()
        {
            if (stack.Any())
            {
                return stack[0];
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
