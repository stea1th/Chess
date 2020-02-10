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
    class FigureModelView
    {

        private readonly IChessGame chessGame = new ChessGame();

        public Turn Turn => chessGame.NewGame();

        public Turn MoveFigure(List<int> coordinates)
        {
            return chessGame.MakeATurn(coordinates[0], coordinates[1]);
        }
    }
}
