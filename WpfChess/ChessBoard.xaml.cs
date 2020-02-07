using System;
using System.Collections.Generic;
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
        public ChessBoard()
        {
            InitializeComponent();
            CreateBoard();
        }

        private void CreateBoard()
        {
            for (var row = 0; row < _boardSize; row++)
            {
                var isBlack = row % 2 == 1;
                for (int col = 0; col < _boardSize; col++)
                {
                    var square = new Rectangle { Fill = isBlack ? Brushes.Black : Brushes.White };
                    SquaresGrid.Children.Add(square);
                    isBlack = !isBlack;
                }
            }
        }
    }
}
