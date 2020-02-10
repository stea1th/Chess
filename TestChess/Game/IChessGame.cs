using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestChess.DTO;

namespace TestChess.Game
{
    public interface IChessGame
    {
        public Turn NewGame();

        //public bool MoveFigure(int from, int to);

        public Turn MakeATurn(string message);

        public Turn MakeATurn(int from, int to);

        //public void TestClick(string message);

    }
}
