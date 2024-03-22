using System.ComponentModel.DataAnnotations;

namespace Blog.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
