using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestChess.DTO;

namespace TestChess.Engine
{
    public interface IChessEngine
    {
        public Turn InitGame();

        public bool MoveFigure(int from, int to);

        public Turn MakeATurn(string message);

    }
}
