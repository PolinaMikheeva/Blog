using System.ComponentModel.DataAnnotations;

namespace Blog.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
    }
}