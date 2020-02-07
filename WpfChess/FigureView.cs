using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestChess.DTO;
using TestChess.Engine;
using TestChess.Figures;

namespace WpfChess
{
    class FigureView
    {
        public Turn Turn => new ChessEngine().NewGame();
    }
}
