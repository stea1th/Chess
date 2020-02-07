using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChess.Figures
{
    class Pawn : AbstractFigure
    {

        public Pawn(int position, bool white) : base("p", "pawn", position, white)
        {
        }
    }
}
