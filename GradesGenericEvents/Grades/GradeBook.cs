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

        private string _name;

        public event EventHandler<NameChangedEventArgs<string>> NameChanged;

        public string name
        {
            get { return _name; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    if (name != value)
                    {
                        NameChangedEventArgs<string> args = new NameChangedEventArgs<string>(_name, value);

                        NameChanged(this, args);
                    }

                    _name = value;
                }
            }
        }

        public GradeBook()
        {
            _name = "Unknown";
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
