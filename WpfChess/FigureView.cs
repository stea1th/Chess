using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestChess.DTO;

using TestChess.Figures;
using TestChess.Game;

namespace WpfChess
{
    class FigureView
    {
        public Turn Turn => new ChessGame().NewGame();
    }
}
