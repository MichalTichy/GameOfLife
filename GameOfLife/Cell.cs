using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GameOfLife
{
    public class Cell
    {
        public State State;
        public readonly int X;
        public readonly int Y;

        public Cell(int x, int y, State state=State.Alive)
        {
            X = x;
            Y = y;
            State = state;
        }

        public override bool Equals(object obj)
        {
            var item = obj as Cell;
            if (item == null)
                return false;

            return Equals(item);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) State;
                hashCode = (hashCode * 397) ^ X;
                hashCode = (hashCode * 397) ^ Y;
                return hashCode;
            }
        }

        protected bool Equals(Cell other)
        {
            return X == other.X && Y == other.Y && State==other.State;
        }
    }

    public enum State
    {
        Alive,
        Death
    }
}