using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezPARATONTOS
{
    public enum FigureColor { WHITE, BLACK }

    public interface IFigure
    {
        FigureColor Color { get; }
    }

    public class Tower : IFigure
    {
        public FigureColor Color { get; }
        public Tower(FigureColor color) => Color = color;
    }

    public class Pawn : IFigure
    {
        public FigureColor Color { get; }
        public Pawn(FigureColor color) => Color = color;
    }
}
