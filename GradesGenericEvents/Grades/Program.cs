using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello");

            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(89.5f);

            GradeBook book2 = book;
            book2.AddGrade(75);

            //book.NameChanged += new NameChangedDelegate(OnNameChanged);
            //book.NameChanged += new NameChangedDelegate(OnNameChanged2);

            book.NameChanged += BookOnNameChanged;

            book.name = "Chris' grades";

            foreach (var aGrade in book.GetGrades())
            {
                Console.WriteLine(aGrade);
            }

            Console.WriteLine("");

            GradeStatistics stats = new GradeStatistics(book);

            stats.ComputeStatistics();
            
            Console.WriteLine(book.name);
            Console.WriteLine($"Average: {stats.GetAverageGrade()}");
            Console.WriteLine($"Highest: {stats.GetHighestGrade()}");
            Console.WriteLine($"Lowest: {stats.GetLowestGrade()}");

        }

        private static void BookOnNameChanged(object sender, NameChangedEventArgs<string> eventArgs)
        {
            Console.WriteLine("Name changed to: " + eventArgs.NewName);
        }


    }


}
