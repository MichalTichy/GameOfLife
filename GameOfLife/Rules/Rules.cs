namespace GameOfLife
{
    public class Rules : IRules
    {
        public Cell Apply(Cell cell, int countOfNeighbours)
        {
            if (cell.State == State.Alive)
                cell.State = countOfNeighbours < 2 || countOfNeighbours > 3 ? State.Death : State.Alive;

            else
                cell.State = countOfNeighbours == 3 ? State.Alive : State.Death;

            return cell;
        }
    }
}