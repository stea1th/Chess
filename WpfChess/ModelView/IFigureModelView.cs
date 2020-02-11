using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using TestChess.DTO;

namespace WpfChess.ModelView
{
    interface IFigureModelView
    {

        public Turn Turn { get; }
        
        public List<Rectangle> CreateBoard();

        public Turn MoveFigure();

        public bool ReadyToMove(int coordinate);
    }
}
