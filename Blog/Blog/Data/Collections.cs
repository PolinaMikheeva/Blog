using Blog.Entities;

namespace Blog.Data
{
    public static class Collections
    {
        public static List<User> Users = new List<User>()
        {
            new User()
            {
                Id = 1,
                FullName = "Name1",
                Email = "Email1"
            },
            new User()
            {
                Id = 2,
                FullName = "Name2",
                Email = "Email2"
            },
            new User()
            {
                Id = 3,
                FullName = "Name3",
                Email = "Email3"
            }
        };

        public static List<Post> Posts = new List<Post>()
        {
            new Post()
            {
                Id = 1,
                Title = "Title1",
                Description = "Description1",
                UserId = 1,
                Complexity = "Complexity1",
                Views = 27,
                MinDescription = "MinDescription1",
                TimeReading = 12
            },
            new Post()
            {
                Id = 2,
                Title = "Title2",
                Description = "Description2",
                UserId = 2,
                Complexity = "Complexity2",
                Views = 1,
                MinDescription = "MinDescription2",
                TimeReading = 5
            },
            new Post()
            {
                Id = 3,
                Title = "Title3",
                Description = "Description3",
                UserId = 3,
                Complexity = "Complexity3",
                Views = 89,
                MinDescription = "MinDescription3",
                TimeReading = 9
            }
        };

        public static List<Tag> Tags = new List<Tag>()
        {
            new Tag()
            {
                Id = 1,
                Name = "Name1"
            },
            new Tag()
            {
                Id = 2,
                Name = "Name2"
            },
            new Tag()
            {
                Id = 3,
                Name = "Name3"
            }
        };
    }
}
