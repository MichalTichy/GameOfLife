using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GameOfLife
{
    public class Cell
    {
        public readonly int X;
        public readonly int Y;

        public Cell(int x, int y)
        {
            Y = y;
            X = x;
        }

        public int GetCauntOfNeighbours(Dictionary<string, Cell> cells)
        {
            int count = 0;
            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    if (x==0 && y == 0) continue;
                    if (cells.ContainsKey($"{X + x}|{Y + y}")) count++;
                }
            }
            return count;
        }

        public override string ToString()
        {
            return $"{X}|{Y}";
        }
    }
}