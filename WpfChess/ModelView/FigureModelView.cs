using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    class FigureModelView : IFigureModelView
    {

        private readonly IChessGame _chessGame = new ChessGame();        
        private readonly List<int> _coordinates = new List<int>();
        private const int _boardSize = 8;

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
                    isBlack = !isBlack;
                }
            }
            return result;
        }

        public Turn Turn => _chessGame.NewGame();

        public Turn MoveFigure()
        {
            var turn = _chessGame.MakeATurn(_coordinates[0], _coordinates[1]);
            _coordinates.Clear();
            return turn;
        }

        public bool ReadyToMove(int coordinate)
        {
            _coordinates.Add(coordinate);
            return _coordinates.Count == 2;
        }
    }
}
