namespace bubbles.api.Models.Entities
{
    public class Post : Entity
    {
        public string Text { get; set; }
        public int UserId { get; set; }
    }
}