using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestChess.DTO;
using TestChess.Figures;
using TestChess.GameConfiguration;
using TestChess.Util;

namespace TestChess.Game
{
    public class ChessGame : IChessGame
    {

        private Dictionary<int, IFigure> _figuresOnPosition;
        private int _killed = 100;
        private bool _whiteMove = true;

        public Turn NewGame()
        {
            var configuration = new ConfigurationReader().GetConfiguration();
            var figureRegistry = new FigureRegistry(configuration);
            _figuresOnPosition = figureRegistry.FiguresOnPosition;            
            return new Turn(_figuresOnPosition, _whiteMove);
        }

        private bool MoveFigure(int from, int to)
        {
            _figuresOnPosition.TryGetValue(from, out var myFigure);
            
            if (myFigure == null) return false;
            _figuresOnPosition.TryGetValue(to, out var anotherFigure);

            if (anotherFigure == null) return ChangeFigurePosition(from, to, myFigure);
            else
            {
                if (myFigure.White == anotherFigure.White) return false;
                else
                {
                    KillFigure(to, anotherFigure);
                    return ChangeFigurePosition(from, to, myFigure);
                }
            }
        }

        public Turn MakeATurn(int from, int to)
        {
            if (MoveFigure(from, to)) _whiteMove = !_whiteMove;
            return new Turn(_figuresOnPosition, _whiteMove);
        }

        public Turn MakeATurn(string message)
        {
            var arr = TurnConverter.Convert(message);
            return MakeATurn(arr[0], arr[1]); 
        }

        private bool ChangeFigurePosition(int from, int to, IFigure figure)
        {
            figure.Position = to;
            _figuresOnPosition.Add(to, figure);
            _figuresOnPosition.Remove(from);
            return true;
        }

        private void KillFigure(int from, IFigure figure)
        {
            figure.Alive = false;
            ChangeFigurePosition(from, _killed++, figure);
        }

    }
}
