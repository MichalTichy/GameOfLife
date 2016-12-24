namespace GameOfLife
{
    public interface IWorldProvider
    {
        World GetNextMove(World world);
    }
}