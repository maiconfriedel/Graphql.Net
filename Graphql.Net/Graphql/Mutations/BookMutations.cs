using Graphql.Net.EntityFramework;
using Graphql.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace Graphql.Net.Graphql.Mutations
{
    public class BookMutations
    {
        public async Task<Book> AddBook(CreateBookModel book, GraphqlDbContext dbContext)
        {
            var createdBook = dbContext.Books.Add(new Book { Author = book.Author, Title = book.Title });

            await dbContext.SaveChangesAsync();

            return createdBook.Entity;

        }

        public async Task<Book?> RemoveBook(int bookId, GraphqlDbContext dbContext)
        {
            var bookToDelete = await dbContext.Books.FirstOrDefaultAsync(a => a.Id == bookId);

            if (bookToDelete != null)
            {
                dbContext.Books.Remove(bookToDelete);
                await dbContext.SaveChangesAsync();

            }

            return bookToDelete;
        }

        public async Task<Book?> EditBook(int bookId, UpdateBookModel newBookData, GraphqlDbContext dbContext)
        {
            var bookToUpdate = await dbContext.Books.FirstOrDefaultAsync(a => a.Id == bookId);

            if (bookToUpdate != null)
            {
                bookToUpdate.Author = newBookData.Author ?? bookToUpdate.Author;
                bookToUpdate.Title = newBookData.Title ?? bookToUpdate.Title;

                await dbContext.SaveChangesAsync();
            }

            return bookToUpdate;
        }
    }
}
