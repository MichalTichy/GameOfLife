using System;
using System.Collections.Generic;
using System.Linq;
using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class GameOfLifeTests
    {
        [TestMethod]
        public void GetNeighbors()
        {
            var dic=new Dictionary<string,Cell>();
            var cell0=new Cell(-1,-1);
            var cell1=new Cell(-1,0);
            var cell2=new Cell(-1,1);
            var cell3=new Cell(0,-1);
            var cell4=new Cell(0,1);
            var cell5=new Cell(1,-1);
            var cell6=new Cell(1,0);
            var cell7=new Cell(1,1);

            dic.Add(cell0.ToString(),cell0);
            dic.Add(cell1.ToString(),cell1);
            dic.Add(cell2.ToString(),cell2);
            dic.Add(cell3.ToString(),cell3);
            dic.Add(cell4.ToString(),cell4);
            dic.Add(cell5.ToString(),cell5);
            dic.Add(cell6.ToString(),cell6);
            dic.Add(cell7.ToString(),cell7);

            Assert.IsTrue(new Cell(0, 0).GetCountOfNeighbors(dic)==8);
            dic.Remove(cell0.ToString());
            Assert.IsTrue(new Cell(0, 0).GetCountOfNeighbors(dic)==7);
            dic.Remove(cell1.ToString());
            Assert.IsTrue(new Cell(0, 0).GetCountOfNeighbors(dic)==6);
            dic.Remove(cell2.ToString());
            Assert.IsTrue(new Cell(0, 0).GetCountOfNeighbors(dic)==5);
            dic.Remove(cell3.ToString());
            Assert.IsTrue(new Cell(0, 0).GetCountOfNeighbors(dic)==4);
            dic.Remove(cell4.ToString());
            Assert.IsTrue(new Cell(0, 0).GetCountOfNeighbors(dic)==3);
            dic.Remove(cell5.ToString());
            Assert.IsTrue(new Cell(0, 0).GetCountOfNeighbors(dic)==2);
            dic.Remove(cell6.ToString());
            Assert.IsTrue(new Cell(0, 0).GetCountOfNeighbors(dic)==1);
            dic.Remove(cell7.ToString());
            Assert.IsTrue(new Cell(0, 0).GetCountOfNeighbors(dic)==0);
        }


        [TestMethod]
        public void NextTurn1()
        {
            Cell[] cells = {
                new Cell(0, 0),
                new Cell(1, 1),
                new Cell(0, 2)
            };
            World nextMove = new World(cells).NextMove();
            Assert.IsTrue(nextMove.Cells.Length == 2);
            Assert.IsTrue(nextMove.Cells.Any(t => t.X == 0 && t.Y == 1));
            Assert.IsTrue(nextMove.Cells.Any(t => t.X == 1 && t.Y == 1));
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

            Assert.IsTrue(nextMove.Cells.Length == 6);
            Assert.IsTrue(nextMove.Cells.Any(t => t.X == 1 && t.Y == 1));
            Assert.IsTrue(nextMove.Cells.Any(t => t.X == 2 && t.Y == 1));
            Assert.IsTrue(nextMove.Cells.Any(t => t.X == 3 && t.Y == 1));
            Assert.IsTrue(nextMove.Cells.Any(t => t.X == 0 && t.Y == 2));
            Assert.IsTrue(nextMove.Cells.Any(t => t.X == 1 && t.Y == 2));
            Assert.IsTrue(nextMove.Cells.Any(t => t.X == 2 && t.Y == 2));
        }
    }
}
