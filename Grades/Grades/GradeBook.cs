﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        private List<float> _grades;

        public string name { get; set; }

        public GradeBook()
        {
            _grades = new List<float>();
        }

        public void AddGrade(float grade)
        {
            _grades.Add(grade);
        }

        public List<float> GetGrades()
        {
            return _grades;
        }

        
    }
}
