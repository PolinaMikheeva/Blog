using Blog.Models.Post;

namespace Blog.Models.Tag
{
    /// <summary>
    /// Тег DTO
    /// </summary>
    public class TagDto
    {
        /// <summary>
        /// Идентификатор тега
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название тега
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Посты
        /// </summary>
        public List<PostDto> Posts { get; set; }
    }
}
