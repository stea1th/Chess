using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChess.Figures
{
    class King : AbstractFigure
    {

        public King(int position, bool white) : base("K", "king", position, white)
        {
        }
    }
}
