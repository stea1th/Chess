using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChess.Figures
{
    public abstract class AbstractFigure : IFigure
    {
        public string Notation { get; set; }
        public string View { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public bool White { get; set; }
        public bool Alive { get; set; }

        //protected AbstractFigure(string notation, string name)
        //{
        //    Notation = notation;
        //    View = (White ? "w" : "b") + notation;
        //    Name = name;
        //}

        protected AbstractFigure(string notation, string name, int position, bool white) 
        {
            Notation = notation;
            View = (white ? "w" : "b") + notation;
            Name = name;
            Position = position;
            White = white;
            Alive = true;
        }
    }
}
