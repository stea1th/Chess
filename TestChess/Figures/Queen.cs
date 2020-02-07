using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChess.Figures
{
    class Queen : AbstractFigure
    {
        public Queen(int position, bool white) : base("Q", "queen", position, white)
        {
        }
    }
}
