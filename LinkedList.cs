namespace DataStructures
{
    public class SinglyLinkedListNode
    {
        public int Value { get; set; }
        public SinglyLinkedListNode Next { get; set; }

        public SinglyLinkedListNode(int value)
        {
            Value = value;
        }
    }

    public class SinglyLinkedList
    {
        SinglyLinkedListNode head;
        SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            head = new SinglyLinkedListNode(-1);
            tail = head;
        }

        public void InsertEnd(int val)
        {
            tail.Next = new SinglyLinkedListNode(val);
            tail = tail.Next;
        }

        public void Remove(int index)
        {
            int i = 0;
            SinglyLinkedListNode curr = head;
            while (i < index && curr != null)
            {
                i++;
                curr = curr.Next;
            }

            // Remove the node ahead of curr
            if (curr != null && curr.Next != null)
            {
                if (curr.Next == tail)
                {
                    tail = curr;
                }
                curr.Next = curr.Next.Next;
            }
        }

        public void Print()
        {
            SinglyLinkedListNode curr = head.Next;
            while (curr != null)
            {
                Console.WriteLine(curr.Value + " -> ");
                curr = curr.Next;
            }
            Console.WriteLine("");
        }
    }

    public class DoublyLinkedListNode
    {
        public int Value { get; set; }
        public DoublyLinkedListNode Prev { get; set; }
        public DoublyLinkedListNode Next { get; set; }

        public DoublyLinkedListNode(int value)
        {
            Value = value;
        }
    }

    public class DoublyLinkedList
    {
        DoublyLinkedListNode head;
        DoublyLinkedListNode tail;

        public DoublyLinkedList()
        {
            head = new DoublyLinkedListNode(-1);
            tail = new DoublyLinkedListNode(-1);
            head.Next = tail;
            tail.Prev = head;
        }

        public void InsertFront(int val)
        {
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(val)
            {
                Prev = head,
                Next = head.Next
            };

            head.Next.Prev = newNode;
            head.Next = newNode;
        }

        public void InsertEnd(int val)
        {
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(val)
            {
                Next = tail,
                Prev = tail.Prev
            };

            tail.Prev.Next = newNode;
            tail.Prev = newNode;
        }

        public void RemoveFront()
        {
            head.Next.Next.Prev = head;
            head.Next = head.Next.Next;
        }

        public void RemoveEnd()
        {
            tail.Prev.Prev.Next = tail;
            tail.Prev = tail.Prev.Prev;
        }

        public void Print()
        {
            DoublyLinkedListNode curr = head.Next;
            while (curr != tail)
            {
                Console.WriteLine(curr.Value + " -> ");
                curr = curr.Next;
            }
            Console.WriteLine("");
        }
    }
}
