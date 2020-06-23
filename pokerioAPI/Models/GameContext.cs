using Microsoft.EntityFrameworkCore;

namespace pokerioAPI.Models {
    public class TodoContext : DbContext {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options) {
        }

        public DbSet<Game> Games{ get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
