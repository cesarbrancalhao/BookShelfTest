using System;
using System.Web.Mvc;
using System.Collections.Generic;

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
		public JsonResult GetBook(string BookName, int BookNumPages, string ISBN)
		{
			//int index = _rnd.Next(_db.Count);
			//var answer = _db[index];
			return Json('a');
		}
		
		private static List<string> _listStrings = new List<string>
		{
			"Works"
		};
	}
}
