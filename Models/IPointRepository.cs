namespace LamartTest.Models;

public interface IPointRepository 
{
    Task<List<Point>> GetPoints();
    Task<bool> DeletePoint(int id);

    Task<Point> AddRandomPoint();
}