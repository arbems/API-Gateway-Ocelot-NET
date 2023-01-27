namespace ServicioA.Dtos;

public class PostDto
{
    public long UserId { get; set; }

    public long Id { get; set; }

    public string? Title { get; set; }

    public string? Body { get; set; }

    //public List<CommentDto> comments = new();
}