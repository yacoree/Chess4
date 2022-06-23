using System;
using System.Text.RegularExpressions;

namespace ChessWPF
{
    public abstract class Piece
    {
        protected int x;
        protected int y;

        public Piece(int newX, int newY)
        {
            x = newX;
            y = newY;
        }

        public abstract bool TestMove(int newX, int newY);
        public bool Move(int newX, int newY)
        {
            if (TestMove(newX, newY))
            {
                x = newX;
                y = newY;
                return true;
            }
            return false;
        }
    }

    public class King : Piece
    {
        public King(int newX, int newY) : base(newX, newY)
        { }

        public override bool TestMove(int newX, int newY)
        {
            return Math.Abs(x - newX) <= 1 && Math.Abs(y - newY) <= 1;
        }
    }

    class Queen : Piece
    {
        public Queen(int newX, int newY) : base(newX, newY)
        { }

        public override bool TestMove(int newX, int newY)
        {
            return (x == newX || y == newY || Math.Abs(x - newX) == Math.Abs(y - newY));
        }
    }

    class Bishop : Piece
    {
        public Bishop(int newX, int newY) : base(newX, newY)
        { }

        public override bool TestMove(int newX, int newY)
        {
            return (Math.Abs(x - newX) == Math.Abs(y - newY));
        }
    }

    class Knight : Piece
    {
        public Knight(int newX, int newY) : base(newX, newY)
        { }
        public override bool TestMove(int newX, int newY)
        {
            return ((Math.Abs(x - newX) == 2 && Math.Abs(y - newY) == 1) ||
                    (Math.Abs(x - newX) == 1 && Math.Abs(y - newY) == 2));
        }
    }

    class Rook : Piece
    {
        public Rook(int newX, int newY) : base(newX, newY)
        { }
        public override bool TestMove(int newX, int newY)
        {
            return (x == newX || y == newY);
        }

    }

    class Pawn : Piece
    {
        public Pawn(int newX, int newY) : base(newX, newY)
        { }

        public override bool TestMove(int newX, int newY)
        {
            return ((x == newX && y == 2 && y + 2 >= newY) ||
                    (x == newX && y + 1 == newY));
        }

    }
}