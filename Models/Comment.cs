namespace LamartTest.Models;

public class Comment
{
    public int Id { get; set; }
    public int PointId { get; set; }
    public string Text { get; set; } = null!;
    public string BackgroundColor { get; set; } = null!;
}