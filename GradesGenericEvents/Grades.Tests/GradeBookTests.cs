using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grades;

namespace Grades.Tests
{
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void ComputeHighestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(20);
            book.AddGrade(30);

            GradeStatistics stats = new GradeStatistics(book);

            stats.ComputeStatistics();

            Assert.AreEqual(30, stats.GetHighestGrade());
        }

        [TestMethod]
        public void ComputeAverageGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = new GradeStatistics(book);

            stats.ComputeStatistics();
            // The third argument, delta, specifies precision for floats
            Assert.AreEqual((float)85.16, (float)stats.GetAverageGrade(), (float)0.01);
        }
    }
}
