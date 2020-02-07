using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestChess.Figures;

namespace TestChess.DTO
{
    public class Turn
    {
        public Dictionary<int, IFigure> Figures;

        public bool WhiteMove;

        public Turn(Dictionary<int, IFigure> figures, bool whiteMove)
        {
            Figures = figures;
            WhiteMove = whiteMove;
        }
    }
}
