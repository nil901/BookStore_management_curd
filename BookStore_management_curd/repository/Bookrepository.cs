using BookStore_management_curd.Models;
using BookStore_management_curd.Models.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore_management_curd.repository
{
    public interface IBookrepository 
    {
        IEnumerable<bookstore> GetBooks();
        bookstore GetBookByID(int bookId);
        void InsertBook(bookstore book);
        void DeleteBook(int bookID);
        void UpdateBook(bookstore book);
        void Save();
    }

    public class Bookrepository : IBookrepository
    {
        private ApplicationDbContext _context; 
         
        public Bookrepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        

        public IEnumerable<bookstore>  GetBooks()
        {
            return _context.book.ToList(); 
        }

        public bookstore GetBookByID(int bookId)
        {
            return _context.book.Find(bookId);
        } 
         public void InsertBook(bookstore book)
        {
            _context.book.Add(book);   


        } 
         
       
       public void UpdateBook(bookstore book)
        {
            _context.Entry(book).State = EntityState.Modified;
        }

        public void DeleteBook(int bookID)
        {
            bookstore book = _context.book.Find(bookID);
            _context.book.Remove(book);  
        }

        public void Save()
        {
            _context.SaveChanges(); 
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
      
    }
}