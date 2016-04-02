using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class World
    {
        private readonly Dictionary<string, Cell> _cells;
        public Cell[] Cells => _cells.Values.ToArray();

        /// <summary>
        /// Create new world from given celtls.
        /// </summary>
        /// <param name="cells">alive cells</param>
        public World(IEnumerable<Cell> cells)
        {
            _cells=new Dictionary<string, Cell>();
            foreach (Cell cell in cells)
            {
                _cells.Add(cell.ToString(),cell);
            }
        }
        private World(Dictionary<string, Cell> cells)
        {
            _cells = cells;
        }

        /// <summary>
        /// Generates new iteration of world.
        /// </summary>
        public World NextMove()
        {
            Dictionary<string, Cell> liveCells= _cells.Where(liveCell => WillBeCellAliveInNextTurn(liveCell.Value, true)).ToDictionary(x => x.Key, x => x.Value);
            AddNewbornsToDictionary(liveCells);
            return new World(liveCells);
        }

        /// <summary>
        /// Adds all cells that will be born in next move to the dictionary.
        /// </summary>
        /// <param name="dictionary">current living cells</param>
        private void AddNewbornsToDictionary(IDictionary<string, Cell> dictionary)
        {
            var allreadyTested=new Dictionary<string, Cell>();

            foreach (KeyValuePair<string, Cell> cell in _cells)
            {
                for (int x = -1; x < 2; x++)
                {
                    for (int y = -1; y < 2; y++)
                    {
                        string nameFormat = $"{cell.Value.X + x}|{cell.Value.Y + y}";
                        if (_cells.ContainsKey(nameFormat)) continue;
                        if (allreadyTested.ContainsKey(nameFormat)) continue;

                        var unbornCell =new Cell(cell.Value.X + x , cell.Value.Y + y);
                        if (WillBeCellAliveInNextTurn(unbornCell,false))
                            dictionary.Add(unbornCell.ToString(),unbornCell);
                        allreadyTested.Add(unbornCell.ToString(),unbornCell);

                    }
                }
            }
        }

        /// <summary>
        /// Implementation of the rules of Conway's Game of Life.
        /// Any live cell with fewer than two live neighbors dies, as if caused by under-population.
        ///  Any live cell with two or three live neighbors lives on to the next generation.
        ///  Any live cell with more than three live neighbors dies, as if by over-population.
        ///  Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
        /// </summary>
        /// <param name="cell">Cell in current move</param>
        /// <param name="isAlive">State of cell</param>
        /// <returns>Whether will be given cell alive in next move.</returns>
        private bool WillBeCellAliveInNextTurn(Cell cell,bool isAlive)
        {
            int countOfNeighbors = cell.GetCountOfNeighbors(_cells);
            if (isAlive)
                return countOfNeighbors == 2 || countOfNeighbors == 3;
            return countOfNeighbors == 3;
        }
    }
}
