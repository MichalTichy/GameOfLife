using System.Collections.Generic;

namespace GameOfLife
{
    public class WorldProvider : IWorldProvider
    {
        private readonly Rules rules;

        public WorldProvider(Rules rules)
        {
            this.rules = rules;
        }

        public World GetNextMove(World world)
        {
            var allFutureCells = GetFutureCellsWithCountOfNeighbours(world);
            return ApplyRules(allFutureCells);
        }

        private World ApplyRules(Dictionary<Cell, int> allFutureCells)
        {
            var aliveCells=new List<Cell>();
            foreach (var futureCell in allFutureCells)
            {
                var cell = rules.Apply(futureCell.Key, futureCell.Value);

                if (cell.State == State.Alive)
                    aliveCells.Add(cell);
            }
            return new World(aliveCells);
        }

        private Dictionary<Cell,int> GetFutureCellsWithCountOfNeighbours(World world)
        {
            var neighbours=new Dictionary<Cell,int>();
            foreach (Cell cell in world)
            {
                AddNeigbouringCellsToSumOfNeighnours(cell, neighbours,world);
            }
            return neighbours;
        }

        private void AddNeigbouringCellsToSumOfNeighnours(Cell cell, Dictionary<Cell, int> neighbours, World world)
        {
            foreach (var neighbouringCell in GetNeighbouringCells(cell,world))
            {
                if (neighbours.ContainsKey(neighbouringCell))
                    neighbours[neighbouringCell]++;
                else
                    neighbours.Add(neighbouringCell, 1);
            }
        }

        public ICollection<Cell> GetNeighbouringCells(Cell cell, World world)
        {
            var cells = new List<Cell>(8);
            for (var x = -1; x < 2; x++)
            {
                for (var y = -1; y < 2; y++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    var neigbouringCell = new Cell(cell.X + x, cell.Y + y);
                    neigbouringCell.State = world.Contains(neigbouringCell) ? State.Alive : State.Death;
                    cells.Add(neigbouringCell);
                }
            }
            return cells;
        }
    }
}