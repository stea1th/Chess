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
        public ObservableCollection<ChessPiece> Pieces { get; set; }

        private const int _boardSize = 8;
        private readonly FigureModelView _figureModelView = new FigureModelView();
        private readonly List<int> _coordinates = new List<int>();

        public ChessBoard()
        {
            Pieces = new ObservableCollection<ChessPiece>();
            InitializeComponent();
            DataContext = this;
            CreateBoard();
            NewGame();
        }

        private void NewGame() => SetFiguresOnChessBoard(_figureModelView.Turn);

        private void CreateBoard()
        {
            for (var row = 0; row < _boardSize; row++)
            {
                var isBlack = row % 2 == 1;
                for (int col = 1; col <= _boardSize; col++)
                {
                    var square = new Rectangle { Fill = isBlack ? Brushes.Black : Brushes.White };
                    square.Uid = (col + _boardSize * row).ToString();
                    SquaresGrid.Children.Add(square);
                    isBlack = !isBlack;
                }
            }
        }

        private void Square_MouseDown(object sender, RoutedEventArgs e)
        {
            var clicked = (Rectangle) e.OriginalSource;
            AddToCoordinates(int.Parse(clicked.Uid));          
        }

        private void Figure_MouseDown(object sender, RoutedEventArgs e)
        {
            var clicked = (Image) e.OriginalSource;
            var piece = (ChessPiece) clicked.DataContext;
            AddToCoordinates(piece.Position);
        }

        private void Move()
        {
            if (_coordinates.Count == 2) SetFiguresOnChessBoard(_figureModelView.MoveFigure(_coordinates));
        }

        private void SetFiguresOnChessBoard(Turn turn)
        {
            Pieces.Clear();
            _coordinates.Clear();
            turn.FiguresOnPosition.Values.ToList().FindAll(x=> x.Alive).ForEach(x => Pieces.Add(new ChessPiece(x.Name, x.Position, x.White)));           
        }

        private void AddToCoordinates(int coordinate)
        {
            _coordinates.Add(coordinate);
            Move();
        }
    }
}
