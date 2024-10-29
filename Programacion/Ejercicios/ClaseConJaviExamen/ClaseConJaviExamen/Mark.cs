using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseConJaviExamen
{
    public enum Subject
    {
        MATH,
        SCIENCE,

    }
    public class Mark
    {
        public double Note;
        public Subject Name;

        public Mark()
        {

        }

        public Mark(double note, Subject name)
        {
            Note = note;
            Name = name;
        }
    }
}
