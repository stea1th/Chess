﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfChess
{
    public class ChessPiece : INotifyPropertyChanged
    {

        public string Name { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public bool IsWhite { get; set; }

        private const int _boardSize = 8;

        public string ImageSource => @"\Pics\" + (IsWhite ? "White" : "Black") + (Name.First().ToString().ToUpper() + Name.Remove(0, 1).ToLower() + ".png");

        public ChessPiece(string name, int position, bool isWhite)
        {
            Name = name;
            IsWhite = isWhite;
            TransformToRowAndColumn(position);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void TransformToRowAndColumn(int position)
        {
            Row = position / _boardSize;
            Column = position - Row * _boardSize - 1;
        }



    }
}
