using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class GameOfLifeTests
    {
        [TestMethod]
        public void NextTurn1()
        {
            Cell[] cells = {
                new Cell(0, 0),
                new Cell(1, 1),
                new Cell(0, 2)
            };
            World nextMove = new World(cells).NextMove();
            Assert.IsTrue(nextMove.Count == 2);
            Assert.IsTrue(nextMove.Any(t => t.X == 0 && t.Y == 1));
            Assert.IsTrue(nextMove.Any(t => t.X == 1 && t.Y == 1));
        }

        [TestMethod]
        public void NextTurn2()
        {
            Cell[] cells = {
                new Cell(2, 0),
                new Cell(0, 1),
                new Cell(0, 2),
                new Cell(3, 1),
                new Cell(3, 2),
                new Cell(1, 3),
            };
            World nextMove = new World(cells).NextMove();

            Assert.IsTrue(nextMove.Count == 6);
            Assert.IsTrue(nextMove.Any(t => t.X == 1 && t.Y == 1));
            Assert.IsTrue(nextMove.Any(t => t.X == 2 && t.Y == 1));
            Assert.IsTrue(nextMove.Any(t => t.X == 3 && t.Y == 1));
            Assert.IsTrue(nextMove.Any(t => t.X == 0 && t.Y == 2));
            Assert.IsTrue(nextMove.Any(t => t.X == 1 && t.Y == 2));
            Assert.IsTrue(nextMove.Any(t => t.X == 2 && t.Y == 2));
        }
    }
}
