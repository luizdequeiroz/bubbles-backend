namespace bubbles.api.Models.Entities
{
    public class Message : Entity
    {
        public string Text { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
    }
}