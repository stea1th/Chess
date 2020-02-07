using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestChess.DTO;
using TestChess.Figures;
using TestChess.GameConfiguration;
using TestChess.Util;

namespace TestChess.Engine
{
    public class ChessEngine : IChessEngine
    {

        private Dictionary<int, IFigure> _figures;

        private int _killed = 100;

        private bool _whiteMove;

        private TurnConverter _turnConverter;

        public Turn InitGame()
        {
            _whiteMove = true;
            _turnConverter = new TurnConverter();
            var confReader = new ConfigurationReader();
            var configuration = confReader.GetConfiguration();
            var figureRegistry = new FigureRegistry(configuration);
            figureRegistry.LoadFigureTypes();
            figureRegistry.SetFiguresOnPosition();
            _figures = figureRegistry.FiguresOnPosition;            
            return new Turn(_figures, _whiteMove);
        }


        public bool MoveFigure(int from, int to)
        {
            _figures.TryGetValue(from, out var myFigure);
            if (myFigure == null) return false;
            _figures.TryGetValue(to, out var anotherFigure);
            if (anotherFigure != null)
            {
                if (myFigure.White == anotherFigure.White) return false;
                else
                {
                    anotherFigure.Alive = false;
                    _figures.Add(_killed, anotherFigure);
                    _figures.Remove(to);
                    _figures.Add(to, myFigure);
                    _figures.Remove(from);
                    _killed++;
                    return true;
                }
            }
            else
            {
                _figures.Add(to, myFigure);
                _figures.Remove(from);
                return true;
            }
        }

        public Turn MakeATurn(string message)
        {
            var arr = _turnConverter.Convert(message);
            if (MoveFigure(arr[0], arr[1])) _whiteMove = !_whiteMove;
            return new Turn(_figures, _whiteMove);
        }

    }
}
