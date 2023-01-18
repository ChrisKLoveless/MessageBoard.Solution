using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Models
{
    public class MessageBoardContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Threads> Threads { get; set; }
        public DbSet<Users> Users { get; set; }

        public MessageBoardContext(DbContextOptions<MessageBoardContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Users>()
            .HasData(
              new Users { UsersId = 1, Name = "Chris" },
              new Users { UsersId = 2, Name = "Yoonis" },
              new Users { UsersId = 3, Name = "Robert" }
            );
            builder.Entity<Threads>()
            .HasData(
              new Threads { UsersId = 1, ThreadsId = 1, Title = "News" },
              new Threads { UsersId = 2, ThreadsId = 2, Title = "Memes" },
              new Threads { UsersId = 3, ThreadsId = 3, Title = "Sports" }
            );
            builder.Entity<Post>()
            .HasData(
              new Post { UsersId = 1, PostId = 1, ThreadsId = 1, Body = "News" },
              new Post { UsersId = 2, PostId = 2, ThreadsId = 2, Body = "Memes" },
              new Post { UsersId = 3, PostId = 3, ThreadsId = 3, Body = "Sports" }
            );
        }
    }
}
