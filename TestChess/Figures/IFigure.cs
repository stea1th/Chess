using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChess.Figures
{
    public interface IFigure
    {
        string Notation { get; set; }
        string View { get; set; }
        string Name { get; set; }
        int Position { get; set; }
        bool White { get; set; }
        bool Alive { get; set; }
    }
}
