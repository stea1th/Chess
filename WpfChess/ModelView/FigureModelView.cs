using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using TestChess.DTO;

using TestChess.Figures;
using TestChess.Game;

namespace WpfChess.ModelView
{
    class FigureModelView
    {

        private readonly IChessGame chessGame = new ChessGame();
        private const int _boardSize = 8;

        public Turn Turn => chessGame.NewGame();

        public Turn MoveFigure(List<int> coordinates) => chessGame.MakeATurn(coordinates[0], coordinates[1]);

        public List<Rectangle> CreateBoard()
        {
            var result = new List<Rectangle>();
            for (var row = 0; row < _boardSize; row++)
            {
                var isBlack = row % 2 == 1;
                for (int col = 1; col <= _boardSize; col++)
                {
                    var square = new Rectangle { Fill = isBlack ? Brushes.Black : Brushes.White };
                    square.Uid = (col + _boardSize * row).ToString();
                    result.Add(square);
                    //SquaresGrid.Children.Add(square);
                    isBlack = !isBlack;
                }
            }
            return result;
        }
    }
}
