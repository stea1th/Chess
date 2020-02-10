using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestChess.DTO;

namespace WpfChess
{
    /// <summary>
    /// Interaktionslogik für ChessBoard.xaml
    /// </summary>
    public partial class ChessBoard : Window
    {

        private const int _boardSize = 8;

        private FigureModelView _figureModelView = new FigureModelView();

        private List<int> _coordinates = new List<int>();

        public ObservableCollection<ChessPiece> Pieces { get; set; }

        public ChessBoard()
        {
            Pieces = new ObservableCollection<ChessPiece>();
            InitializeComponent();
            DataContext = this;
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

        private void Square_MouseDown(object sender, RoutedEventArgs e)
        {
            var clicked = (Rectangle) e.OriginalSource;
            _coordinates.Add(int.Parse(clicked.Uid));
            Move();
        }

        private void Figure_MouseDown(object sender, RoutedEventArgs e)
        {
            var clicked = (Image) e.OriginalSource;
            var piece = (ChessPiece) clicked.DataContext;
            _coordinates.Add(piece.Position);
            Move();
        }

        private void Move()
        {
            if(_coordinates.Count == 2)
            {
                var turn = _figureModelView.MoveFigure(_coordinates);
                turn.FiguresOnPosition.Values.ToList().ForEach(x => Console.WriteLine(x.Name + " " + x.Position));
                FillPieces(turn);
            }
        }

        private void NewGame()
        {
            var turn = _figureModelView.Turn;
            FillPieces(turn);
        }

        private void FillPieces(Turn turn)
        {
            Pieces.Clear();
            turn.FiguresOnPosition.Values.ToList().ForEach(x => Pieces.Add(new ChessPiece(x.Name, x.Position, x.White)));
            Pieces.ToList().ForEach(x => Console.WriteLine(x.Name + " " + x.Position));
            _coordinates.Clear();
        }
    }
}
