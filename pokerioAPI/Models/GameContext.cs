using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace pokerioAPI.Models {
    public class TodoContext : IdentityDbContext<Player> {
        //public TodoContext(DbContextOptions<TodoContext> options)
        //  : base(options) {
        //}
        public TodoContext() : base("ConnectionStringLocal") { }

        public DbSet<Game> Games{ get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
