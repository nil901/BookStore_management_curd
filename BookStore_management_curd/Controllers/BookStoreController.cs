using BookStore_management_curd.Models;
using BookStore_management_curd.Models.Context;
using BookStore_management_curd.repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore_management_curd.Controllers
{
    public class BookStoreController : Controller
    {
        private readonly IBookrepository _bookrepository;
       

        public BookStoreController()
        {
            _bookrepository = new Bookrepository(new ApplicationDbContext());
       
        } 

         public ActionResult Index()   
        {
            var books = from book in _bookrepository.GetBooks()    //using linq
                        select book;
            return View(books);
        }
        public ViewResult Details(int id)
        {
            bookstore bookstore = _bookrepository.GetBookByID(id);

             return View(bookstore);
        }

        public ActionResult Create()
        {
            return View(new bookstore());
        }

        [HttpPost]
        public ActionResult create(bookstore bookstore)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookrepository.InsertBook(bookstore);
                    _bookrepository.Save();
                    return RedirectToAction("Index");

                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(  bookstore);

        }

        public ActionResult Edit(int id)
        {
            bookstore book = _bookrepository.GetBookByID(id);
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(bookstore book)
        {
            try
            {
                _bookrepository.UpdateBook(book);
                _bookrepository.Save();
                return RedirectToAction("Index");
            }
            catch (DataException)

            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator."); 


            }
            return View(book); 

          }

        public ActionResult Delete(int id , bool? saveChangeError)
        {
            if (saveChangeError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = " Unable to save changes.Try again, and if the problem persists see your system administrator.";
            }
            bookstore book = _bookrepository.GetBookByID(id);
            return View (book);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                bookstore book = _bookrepository.GetBookByID(id);
                _bookrepository.DeleteBook(id);
                _bookrepository.Save(); 
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                   new System.Web.Routing.RouteValueDictionary {
                  { "id", id },
                  { "saveChangesError", true } });
            }

            return RedirectToAction("Index");

        } 


       



    }
}