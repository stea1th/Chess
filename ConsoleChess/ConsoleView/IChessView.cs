using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestChess.DTO;

namespace ConsoleChess.ConsoleView
{
    public interface IChessView
    {
        public void PrintBoard(Turn turn);

        public string ReadFromConsole();

    }
}
