using System;
using System.Collections.Generic;
using PracticeTest.Entities;

namespace PracticeTest.Service
{
    public interface IBookService
    {
        void AddBook(Book book);
        List<Book> GetAllBooks();
        Book GetBookById(int bookId);
        void UpdateBook(Book book);
        void DeleteBook(int bookId);
    }
}
