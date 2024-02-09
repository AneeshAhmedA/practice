using System;
using System.Collections.Generic;
using PracticeTest.Entities;
using PracticeTest.Database;
using Microsoft.EntityFrameworkCore;

namespace PracticeTest.Service
{
    public class BookService : IBookService
    {
        private readonly Mycontext _context;

        public BookService(Mycontext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int bookId)
        {
            return _context.Books.Find(bookId);
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}
