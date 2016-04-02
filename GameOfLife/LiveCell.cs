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

        /// <summary>
        /// Creates new cell.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Cell(int x, int y)
        {
            Y = y;
            X = x;
        }

        /// <summary>
        /// Gets count of sorounding neighbors.
        /// </summary>
        /// <param name="cells">All alive cells in current world.</param>
        /// <returns>Count of sorounding neighbors. Possible values are 0 - 9</returns>
        public int GetCountOfNeighbors(Dictionary<string, Cell> cells)
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

        /// <summary>
        /// String representation of cells coordinates.
        /// </summary>
        /// <returns>xCord|yCord</returns>
        public override string ToString()
        {
            return $"{X}|{Y}";
        }
    }
}