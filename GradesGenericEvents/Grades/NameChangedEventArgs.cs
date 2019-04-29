using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class NameChangedEventArgs<T> : EventArgs
    {
        public NameChangedEventArgs(T existingName, T newName)
        {
            ExistingName = existingName;
            NewName = newName;
        }
        public T ExistingName { get; set; }
        public T NewName { get; set; }
    }
}
