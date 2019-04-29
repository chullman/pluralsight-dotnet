using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListGenerics
{
    class Program
    {
        // Linked list makes it easy to modify specific indexes by being able to look at previous and next elements

        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AddFirst(2);
            list.AddFirst(3);

            var first = list.First;
            list.AddAfter(first, 5);

            // note the type of list.First is a node object
            var node = list.First;

            while (node != null)
            {
                Console.WriteLine(node.Value);

                node = node.Next;

            }
        }
    }
}
