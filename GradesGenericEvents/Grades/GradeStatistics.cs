using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Grades
{
    public class GradeStatistics
    {
       private float? _averageGrade = null;
       private float? _highestGrade = null;
       private float? _lowestGrade = null;

        private GradeBook _book;

        public GradeStatistics(GradeBook book)
        {
            _book = book;
        }

        public void ComputeStatistics()
        {

            _highestGrade = 0;

            if (_book.GetGrades().Count == 0)
            {
                _lowestGrade = 0;
                _averageGrade = 0;
            }
            else
            {
                _lowestGrade = float.MaxValue;
                _averageGrade = _book.GetGrades().Sum() / _book.GetGrades().Count;
            }

            foreach (float grade in _book.GetGrades())
            {
                _highestGrade = Math.Max(grade, (float)_highestGrade);
                _lowestGrade = Math.Min(grade, (float)_lowestGrade);

            }
            
        }

        public float? GetHighestGrade()
        {
            return _highestGrade;
        }

        public float? GetLowestGrade()
        {
            return _lowestGrade;
        }

        public float? GetAverageGrade()
        {
            return _averageGrade;
        }

    }
}
