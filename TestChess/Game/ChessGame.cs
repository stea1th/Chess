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

        private bool _whiteMove;

        private TurnConverter _turnConverter;

        public Turn NewGame()
        {
            _whiteMove = true;
            _turnConverter = new TurnConverter();
            var confReader = new ConfigurationReader();
            var configuration = confReader.GetConfiguration();
            var figureRegistry = new FigureRegistry(configuration);
            figureRegistry.LoadFigureTypes();
            figureRegistry.SetFiguresOnPosition();
            _figuresOnPosition = figureRegistry.FiguresOnPosition;            
            return new Turn(_figuresOnPosition, _whiteMove);
        }

        private bool MoveFigure(int from, int to)
        {
            _figuresOnPosition.TryGetValue(from, out var myFigure);
            if (myFigure == null) return false;
            _figuresOnPosition.TryGetValue(to, out var anotherFigure);
            if (anotherFigure != null)
            {
                if (myFigure.White == anotherFigure.White) return false;
                else
                {
                    anotherFigure.Alive = false;
                    anotherFigure.Position = _killed;
                    myFigure.Position = to;
                    _figuresOnPosition.Add(_killed, anotherFigure);
                    _figuresOnPosition.Remove(to);
                    _figuresOnPosition.Add(to, myFigure);
                    _figuresOnPosition.Remove(from);
                    _killed++;
                    return true;
                }
            }
            else
            {
                myFigure.Position = to;
                _figuresOnPosition.Add(to, myFigure);
                _figuresOnPosition.Remove(from);
                return true;
            }
        }

        public Turn MakeATurn(int from, int to)
        {
            if(MoveFigure(from, to)) _whiteMove = !_whiteMove;
            return new Turn(_figuresOnPosition, _whiteMove);
        }

        public Turn MakeATurn(string message)
        {
            var arr = _turnConverter.Convert(message);
            return MakeATurn(arr[0], arr[1]); 
        }

    }
}
