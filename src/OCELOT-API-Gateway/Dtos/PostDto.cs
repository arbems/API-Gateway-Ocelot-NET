namespace OCELOT_API_Gateway.Dtos
{
    public class PostDto
    {       
        public long Id { get; set; }

        public string? Title { get; set; }

        public string? Body { get; set; }

        public long UserId { get; set; }

        public UserDto User { get; set; }

        //public List<CommentDto> comments = new();
    }
}