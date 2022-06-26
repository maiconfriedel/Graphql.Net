using Graphql.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace Graphql.Net.EntityFramework
{
    public class GraphqlDbContext : DbContext
    {
        public GraphqlDbContext()
        {

        }

        public GraphqlDbContext(DbContextOptions<GraphqlDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
