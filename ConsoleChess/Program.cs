using ConsoleChess.ConsoleView;
using TestChess.Game;

namespace ConsoleChess
{
    class Program
    {
        protected Program()
        {
        }

        static void Main(string[] args)
        {
            IChessGame chessEngine = new ChessGame();
            IChessView chessBoard = new ChessView();
            var turn = chessEngine.NewGame();
            while (true)
            {
                chessBoard.PrintBoard(turn);
                var message = chessBoard.ReadFromConsole();
                turn = chessEngine.MakeATurn(message);
            }
        }
    }
}
