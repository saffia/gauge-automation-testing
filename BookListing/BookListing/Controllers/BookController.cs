using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookListing.Models;

namespace BookListing.Controllers
{
    public class BookController : Controller
    {
	    public IList<Book> Books
	    {
		    get
		    {
			    return new List<Book>()
			    {
				    new Book {Author = "Steve McConnell", Title = "Code Complete 2"},
				    new Book {Author = "Frederick P Brooks Jr", Title = "The Mythical Man Month"},
				    new Book {Author = "Dan Norman", Title = "The Design of Everyday Things"}
			    };
		    }
	    }

		[HttpGet]
        public ActionResult Index()
        {
			return View(Books);
        }

		[HttpPost]
		public ActionResult Search(string title)
		{
			var searchResult = Books;
			if (!string.IsNullOrEmpty(title))
			{
				var foundItems = Books.Where(b => b.Title.ToLower().Contains(title.ToLower()));
				searchResult = new List<Book>();

				if (foundItems.Any())
				{
					foreach (var item in foundItems)
					{
						searchResult.Add(item);
					}
				}
				else
				{
					throw new Exception("no result found");
				}
			}


			return Json(searchResult);
		}
    }
}