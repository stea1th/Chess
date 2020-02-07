using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfChess
{
    /// <summary>
    /// Interaktionslogik für ChessBoard.xaml
    /// </summary>
    public partial class ChessBoard : Window
    {

        private const int _boardSize = 8;

        public ObservableCollection<ChessPiece> Pieces { get; set; }

        public ChessBoard()
        {
            InitializeComponent();
            CreateBoard();
            NewGame();
        }

        private void CreateBoard()
        {
            for (var row = 0; row < _boardSize; row++)
            {
                var isBlack = row % 2 == 1;
                for (int col = 1; col <= _boardSize; col++)
                {
                    var square = new Rectangle { Fill = isBlack ? Brushes.Black : Brushes.White };
                    string num = (col + _boardSize * row).ToString();
                    square.Uid = num;
                    SquaresGrid.Children.Add(square);
                    isBlack = !isBlack;
                }
            }
        }

        private void NewGame()
        {
            var figureView = new FigureView();
            var turn = figureView.Turn;
            turn.Figures.Values.ToList().ForEach(x => Pieces.Add(new ChessPiece(x.Name, x.Position, x.White)));

        }
    }
}
