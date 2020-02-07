using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChess.Figures
{
    class Knight : AbstractFigure
    {
        public Knight(int position, bool white) : base("N", "knight", position, white)
        {
        }
    }
}
