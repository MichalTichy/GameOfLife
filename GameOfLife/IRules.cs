namespace GameOfLife
{
    public interface IRules
    {
        Cell Apply(Cell cell, int countOfNeighbours);
    }
}