using LamartTest.Models;
using Microsoft.EntityFrameworkCore;

namespace LamartTest.Context;

public class PointRepository : IPointRepository
{
    private readonly PointsDbContext _pointsDb;

    public PointRepository(PointsDbContext context)
    {
        _pointsDb = context;
    }

    public async Task<List<Point>> GetPoints()
    {
        var points = await _pointsDb.Points.ToListAsync();
        foreach (var item in points)
        {
            item.CommentsUnderPoint = await GetComments(item.Id);
        }

        return points;
    }

    private async Task<List<Comment>> GetComments(int pointId)
    {
        return await _pointsDb.Comments.Where(i => i.PointId == pointId).ToListAsync();
    }

    public async Task<bool> DeletePoint(int id)
    {
        var point = await _pointsDb.Points.FirstOrDefaultAsync(i => i.Id == id);
        if (point != null)
        {
            _pointsDb.Points.Remove(point);
            await _pointsDb.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<Point> AddRandomPoint()
    {
        var random = new Random();

        string GetRandomColor()
        {
            return $"#{random!.Next(0x1000000):X6}";
        }

        var point = new Point
        {
            XPos = random.Next(200, 1000),
            YPos = random.Next(200, 800),
            Radius = random.Next(20, 50),
            Color = GetRandomColor(),
        };

        await _pointsDb.Points.AddAsync(point);
        await _pointsDb.SaveChangesAsync();

        for (var i = 0; i < random.Next(2, 5); i++)
        {
            var comment = new Comment()
            {
                Text = $"Comment {i + 1}",
                BackgroundColor = GetRandomColor(),
                PointId = point.Id
            };

            await _pointsDb.Comments.AddAsync(comment);
        }

        await _pointsDb.SaveChangesAsync();

        return point;
    }
}