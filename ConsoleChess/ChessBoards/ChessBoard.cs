using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestChess.DTO;
using TestChess.Figures;

namespace ConsoleChess.ChessBoards
{
    public class ChessBoard : IChessBoard
    {

        private const int _boardSize = 8;
        private const string _threeSpaces = "   ";
        private const string _twoSpaces = "  ";
        private const string _oneSpace = " ";
        private readonly string _lettersCoordinates;

        public ChessBoard()
        {
            _lettersCoordinates = CreateLettersCoordinates();
        }

        public void PrintBoard(Turn turn)
        {
            if (turn.WhiteMove) PrintForWhite(turn.Figures);
            else PrintForBlack(turn.Figures);
        }

        private void PrintForWhiteNumbers()
        {
            for (int row = 0; row < _boardSize; row++)
            {
                Console.WriteLine();
                Console.WriteLine("---------------------------------");
                for (int column = 1; column <= _boardSize; column++)
                {
                    string num = (column + _boardSize * row).ToString();
                    Console.Write("| " + (num.Length == 1 ? num + _oneSpace : num));
                }
                Console.Write("|");
            }
            Console.WriteLine();
            Console.WriteLine("---------------------------------");
        } 

        private void PrintForWhite(Dictionary<int, IFigure> figures)
        {
            for (int row = 0; row < _boardSize; row++)
            {
                Console.WriteLine();
                Console.WriteLine(_threeSpaces + "---------------------------------");
                for (int column = 0; column <= _boardSize; column++)
                {
                    if(column == 0)
                    {
                        Console.Write(_oneSpace + (_boardSize - row) + _oneSpace);
                    } 
                    else
                    {
                        int num = column + _boardSize * row;
                        figures.TryGetValue(num, out var figure);
                        string cell = figure != null && figure.Alive ? _oneSpace + figure.View : GetEmptyCell(row, num, true);
                        Console.Write("|" + cell);
                    }
                }
                Console.Write("|");
            }
            Console.WriteLine();
            Console.WriteLine(_threeSpaces + "---------------------------------");
            Console.WriteLine(_threeSpaces + _lettersCoordinates);
            Console.WriteLine();
        } 

        private void PrintForBlack(Dictionary<int, IFigure> figures)
        {
            for (int row = _boardSize; row > 0; row--)
            {
                Console.WriteLine();
                Console.WriteLine(_threeSpaces + "---------------------------------");
                for (int column = 0; column <= _boardSize; column++)
                {
                    if(column == 0)
                    {
                        Console.Write(_oneSpace + (_boardSize - row + 1) + _oneSpace);
                    }
                    else
                    {
                        int num = _boardSize * row - column + 1;
                        figures.TryGetValue(num, out var figure);
                        string cell = figure != null && figure.Alive ? _oneSpace + figure.View : GetEmptyCell(row, num, false);
                        Console.Write("|" + cell);
                    }
                }
                Console.Write("|");
            }
            Console.WriteLine();
            Console.WriteLine(_threeSpaces + "---------------------------------");
            Console.WriteLine(_threeSpaces + _twoSpaces + ReverseLettersCoordinates());
            Console.WriteLine();
        }

        private string CreateLettersCoordinates()
        {
            var letters = Enumerable.Range(65, 72).Select(x => (char)x).ToList().GetRange(0, 8);
            var stringBuilder = new StringBuilder(_twoSpaces);
            letters.ForEach(x => stringBuilder.Append(x).Append(_threeSpaces));
            return stringBuilder.ToString();
        }

        private string ReverseLettersCoordinates()
        {
            var arr = _lettersCoordinates.Trim().ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }


        private string GetEmptyCell(int row, int num, bool isWhite)
        {
            string white = _threeSpaces;
            string black = "===";
            int expr = isWhite ? 1 : 0;
            if(row % 2 == 0)
            {
                return num % 2 == expr ? white : black;
            }
            else
            {
                return num % 2 == expr ? black : white;
            }
        }

        public string ReadFromConsole()
        {
            Console.WriteLine("Your move:");
            return Console.ReadLine();
        }        
    }
}
