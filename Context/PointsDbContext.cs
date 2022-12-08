using LamartTest.Models;
using Microsoft.EntityFrameworkCore;

namespace LamartTest.Context;

public class PointsDbContext : DbContext
{
    public DbSet<Point> Points { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=Points; Trusted_Connection=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Point>().HasData(
            new Point
            {
                Id = 1,
                XPos = 500,
                YPos = 80,
                Radius = 50,
                Color = "Yellow"
            },
            new Point
            {
                Id = 2,
                XPos = 800,
                YPos = 150,
                Radius = 20,
                Color = "Green"
            },
            new Point
            {
                Id = 3,
                XPos = 1300,
                YPos = 500,
                Radius = 20,
                Color = "Blue"
            });
                    
        modelBuilder.Entity<Comment>().HasData(
            new Comment
            {
                Id = 1,
                Text = "Comment 1",
                BackgroundColor = "null",
                PointId = 1
            },
            new Comment
            {
                Id = 2,
                Text = "Comment 2",
                BackgroundColor = "Grey",
                PointId = 1
            },
            new Comment
            {
                Id = 3,
                Text = "Comment 3",
                BackgroundColor = "null",
                PointId = 1
            },
            new Comment
            {
                Id = 4,
                Text = "Comment 4",
                BackgroundColor = "Aqua",
                PointId = 2
            },
            new Comment
            {
                Id = 5,
                Text = "Comment 5",
                BackgroundColor = "Blue",
                PointId = 2
            },
            new Comment
            {
                Id = 6,
                Text = "Comment 6 looooooooooooooooooong",
                BackgroundColor = "Yellow",
                PointId = 2
            },
            new Comment
            {
                Id = 7,
                Text = "Comment 7",
                BackgroundColor = "Grey",
                PointId = 2
            },
            new Comment
            {
                Id = 8,
                Text = "Comment 8",
                BackgroundColor = "null",
                PointId = 3
            },
            new Comment
            {
                Id = 9,
                Text = "Comment 9",
                BackgroundColor = "brown",
                PointId = 3
            });
    }
}