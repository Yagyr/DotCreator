using System.Text.Json.Serialization;

namespace LamartTest.Models;

public class Point
{
    public int Id { get; set; }
    public int XPos { get; set; }
    public int YPos { get; set; }
    public int Radius { get; set; }
    public string Color { get; set; }
    
    [JsonPropertyName("comments")]
    public List<Comment> CommentsUnderPoint { get; set; }
}