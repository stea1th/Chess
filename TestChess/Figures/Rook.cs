using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChess.Figures
{
    class Rook : AbstractFigure
    {
        public Rook(int position, bool white) : base("R", "rook", position, white)
        {
        }
    }
}
