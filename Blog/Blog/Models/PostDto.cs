using Blog.Entities;

namespace Blog.Models
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string MinDescription { get; set; }
        public int Views { get; set; }
        public int TimeReading { get; set; }
        public string Complexity { get; set; }

        public User User { get; set; }

        public Tag Tag { get; set; }
    }
}
