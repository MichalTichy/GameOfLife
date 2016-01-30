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

        public World NextMove()
        {
            Dictionary<string, Cell> liveCells= _cells.Where(liveCell => WillBeCellAliveInNextTurn(liveCell.Value, true)).ToDictionary(x => x.Key, x => x.Value);
            AddNewBornsToDictionary(liveCells);
            return new World(liveCells);
        }

        private void AddNewBornsToDictionary(IDictionary<string, Cell> dictionary)
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

        private bool WillBeCellAliveInNextTurn(Cell cell,bool isAlive)
        {
            int countOfNeighbours = cell.GetCauntOfNeighbours(_cells);
            if (isAlive)
                return countOfNeighbours == 2 || countOfNeighbours == 3;
            return countOfNeighbours == 3;
        }
    }
}
