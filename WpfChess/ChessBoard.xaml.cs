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
using WpfChess.ModelView;

namespace WpfChess
{
    /// <summary>
    /// Interaktionslogik für ChessBoard.xaml
    /// </summary>
    public partial class ChessBoard : Window
    {
        public ObservableCollection<ChessPiece> Pieces { get; set; }

        private readonly IFigureModelView _figureModelView = new FigureModelView();

        public ChessBoard()
        {
            Pieces = new ObservableCollection<ChessPiece>();
            InitializeComponent();
            DataContext = this;
            CreateBoard();
            NewGame();
        }

        private void NewGame() => SetFiguresOnChessBoard(_figureModelView.NewGame());

        private void CreateBoard() => _figureModelView.CreateBoard().ForEach(x => SquaresGrid.Children.Add(x));

        private void Square_MouseDown(object sender, RoutedEventArgs e)
        {
            var clicked = (Rectangle)e.OriginalSource;
            TryToMove(int.Parse(clicked.Uid));
        }

        private void Figure_MouseDown(object sender, RoutedEventArgs e)
        {
            var clicked = (Image)e.OriginalSource;
            var piece = (ChessPiece)clicked.DataContext;
            TryToMove(piece.Position);
        }

        private void TryToMove(int position)
        {
            if (_figureModelView.ReadyToMove(position))
                SetFiguresOnChessBoard(_figureModelView.MoveFigure());
        }

        private void SetFiguresOnChessBoard(Turn turn)
        {
            Pieces.Clear();
            turn.FiguresOnPosition.Values.ToList()
                .FindAll(x => x.Alive).ForEach(x => Pieces.Add(new ChessPiece(x.Name, x.Position, x.White)));
        }
    }
}
