using System.Web.Mvc;

namespace Bookshelf
{
    public class BookController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Book());
        }

        [HttpPost]
        public JsonResult GetBook(Book book)
        {
            if (ModelState.IsValid)
            {
                var result = BookBusiness.ProcessBook(book);
                return Json(result);
            }
            return Json("Invalid book, check your data.");
        }
    }
}