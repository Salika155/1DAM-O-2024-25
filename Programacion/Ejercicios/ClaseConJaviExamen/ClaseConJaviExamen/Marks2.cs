using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseConJaviExamen
{
    public class Marks2
    {
        public enum Subject
        {
            MATH,
            SCIENCE,

        }
        public class Mark
        {
            private readonly List<double> _notesprivates = new();
            public readonly Subject Name;

            public Mark(Subject subject)
            {
                Name = subject;
            }

            public void Add(double mark)
            {

            }

            
        }


    }
}
