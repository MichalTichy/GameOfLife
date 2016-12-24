using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class World : HashSet<Cell>
    {
        private readonly WorldProvider worldProvider;

        public World()
        {
        }

        public World(ICollection<Cell> cells)
        {
            Add(cells);
            worldProvider=new WorldProvider(new Rules());
        }

        public World(ICollection<Cell> cells,WorldProvider worldProvider)
        {
            this.worldProvider = worldProvider;
            Add(cells);
        }

        private void Add(ICollection<Cell> cells)
        {
            foreach (var cell in cells)
                Add(cell);
        }

        public World NextMove()
        {
            return worldProvider.GetNextMove(this);
        }
    }
}
