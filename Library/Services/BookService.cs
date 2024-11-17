using Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace Library.Services
{
    public class BookService
    {
        private readonly List<Book> _books = new();

        public IEnumerable<Book> GetAllBooks() => _books;

        public Book GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public void AddBook(Book book) => _books.Add(book);

        public bool RemoveBook(int id)
        {
            var book = GetBookById(id);
            if (book == null) return false;

            _books.Remove(book);
            return true;
        }

        public bool RentBook(int id)
        {
            var book = GetBookById(id);
            if (book == null || book.Stock <= 0) return false;

            book.Stock--;
            return true;
        }

        public void DonateBook(Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Title == book.Title && b.Author == book.Author);
            if (existingBook != null)
            {
                existingBook.Stock++;
            }
            else
            {
                _books.Add(book);
            }
        }
    }
}
