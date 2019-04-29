using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueGeneric
{
    class Program
    {

        // Queue is a FIFO structure

        static void Main(string[] args)
        {
            Queue<string> line = new Queue<string>();
            line.Enqueue("person1");
            line.Enqueue("person2");
            line.Enqueue("person3");

            while (line.Count > 0)
            {
                Console.WriteLine(line.Dequeue());
            }
        }
    }
}
