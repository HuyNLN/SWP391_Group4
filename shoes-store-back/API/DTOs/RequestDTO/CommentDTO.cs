namespace API.DTOs.RequestDTO
{
    public class CommentDTO
    {
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public string? Content { get; set; }
    }
}
