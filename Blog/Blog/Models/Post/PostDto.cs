using Blog.Models.Tag;
using Blog.Models.User;

namespace Blog.Models.Post
{
    /// <summary>
    /// Пост DTO
    /// </summary>
    public class PostDto
    {
        /// <summary>
        /// Идентификатор поста
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название поста
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание поста
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Краткое описание поста
        /// </summary>
        public string MinDescription { get; set; }

        /// <summary>
        /// Просмотры
        /// </summary>
        public int Views { get; set; }

        /// <summary>
        /// Время чтения поста
        /// </summary>
        public int TimeReading { get; set; }

        /// <summary>
        /// Сложность
        /// </summary>
        public string Complexity { get; set; }

        /// <summary>
        /// Автор поста
        /// </summary>
        public UserDto User { get; set; }
        public string UserFullName { get; set; }

        /// <summary>
        /// Теги
        /// </summary>
        public List<TagDto> Tags { get; set; }
    }
}
