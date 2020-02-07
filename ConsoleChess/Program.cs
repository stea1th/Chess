
using ConsoleChess.ChessBoards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestChess.Engine;

namespace ConsoleChess
{
    class Program
    {
        protected Program()
        {
        }

        static void Main(string[] args)
        {
            IChessEngine chessEngine = new ChessEngine();
            IChessBoard chessBoard = new ChessBoard();
            var turn = chessEngine.InitGame();
            while (true)
            {
                chessBoard.PrintBoard(turn);
                var message = chessBoard.ReadFromConsole();
                turn = chessEngine.MakeATurn(message);
            }
        }
    }
}
