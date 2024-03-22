using System.ComponentModel.DataAnnotations;

namespace Blog.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string MinDescription { get; set; }
        public int Views { get; set; }
        public int TimeReading { get; set; }
        public string Complexity { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
