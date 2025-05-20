using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprint
{
    public class Color
    {
        private double _r;
        private double _g;
        private double _b;
        private double _a;

        public double R => _r;
        public double G => _g;
        public double B => _b;
        public double A => _a;

        public Color(double r, double g, double b, double a)
        {
            _r = r;
            _g = g;
            _b = b;
            _a = a;
        }

        //public Color GetColor(double r, double g, double b, double a)
        //{
        //    return new Color(r, g, b, a);
        //}
    }
}
