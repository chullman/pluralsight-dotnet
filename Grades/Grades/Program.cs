using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(89.5f);

            GradeBook book2 = book;
            book2.AddGrade(75);

            foreach (var aGrade in book.GetGrades())
            {
                Console.WriteLine(aGrade);
            }

            Console.WriteLine("");

            GradeStatistics stats = new GradeStatistics(book);

            stats.ComputeStatistics();

            Console.WriteLine($"Average: {stats.GetAverageGrade()}");
            Console.WriteLine($"Highest: {stats.GetHighestGrade()}");
            Console.WriteLine($"Lowest: {stats.GetLowestGrade()}");

        }
    }
}
