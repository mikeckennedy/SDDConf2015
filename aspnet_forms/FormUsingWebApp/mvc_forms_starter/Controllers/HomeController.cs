using System;
using System.Linq;
using System.Web.Mvc;
using mvc_forms_starter.core.Models;

namespace mvc_forms_starter.Controllers
{
	public class HomeController : BaseController
	{
		// Step 1: Make view strongly typed.
		public ActionResult Index()
		{
			Category[] categories = repository.Categories.ToArray();
			//ViewData["Categories"] = categories;
			//ViewBag.Categories = categories;

			return View(categories);
		}

		public ActionResult ShowDangerText()
		{
			ViewBag.Text = "This is my <strong>message</strong>";
			return View();
		}
	}
}