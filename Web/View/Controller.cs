using System;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Bookshelf
{
    public class BookController : Controller
    {
        private static List<Book> _bookList = new List<Book>();

        [HttpGet]
        public ActionResult Index()
        {
            return View(new Book());
        }

        [HttpPost]
        public ActionResult InsertBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookList.Add(book);
                return Json(new { success = true, message = "Book inserted successfully" });
            }

            return Json(new { success = false, message = "Invalid book data" });
        }

        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            if (ModelState.IsValid)
            {
                var existingBook = _bookList.Find(b => b.ISBN == book.ISBN);

                if (existingBook != null)
                {
                    existingBook.BookName = book.BookName;
                    existingBook.BookNumPages = book.BookNumPages;
                    return Json(new { success = true, message = "Book edited successfully" });
                }

                return Json(new { success = false, message = "Book not found" });
            }

            return Json(new { success = false, message = "Invalid book data" });
        }

        [HttpGet]
        public ActionResult GetBookList()
        {
            return Json(_bookList, JsonRequestBehavior.AllowGet);
        }
    }
}
