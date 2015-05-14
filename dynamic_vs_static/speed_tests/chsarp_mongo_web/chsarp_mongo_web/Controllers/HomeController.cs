using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chsarp_mongo_web.Mongo;

namespace chsarp_mongo_web.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult PerfTest()
		{
			var mongo = new MongoContext();
			ViewBag.Count = mongo.Books.Count();
			ViewBag.Book = mongo.Books.FirstOrDefault(b => b.ISBN == "0671004530");
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}