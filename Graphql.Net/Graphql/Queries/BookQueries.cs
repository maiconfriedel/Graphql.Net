using Graphql.Net.EntityFramework;
using Graphql.Net.Models;

namespace Graphql.Net.Graphql.Queries
{
    public class BookQueries
    {
        [UseFiltering]
        public IQueryable<Book> GetBooks(GraphqlDbContext dbContext) => dbContext.Books.AsQueryable();

        public Book? GetBook(int bookId, GraphqlDbContext dbContext) => dbContext.Books.FirstOrDefault(a => a.Id == bookId);

    }
}
