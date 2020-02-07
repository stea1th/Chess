using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChess.Figures
{
    class Bishop : AbstractFigure
    {
        public Bishop(int position, bool white) : base("B", "bishop", position, white)
        {
        }

    }
}
