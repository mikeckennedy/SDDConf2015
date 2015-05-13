using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_forms_starter.ViewModels;

namespace mvc_forms_starter.Controllers
{
    public class CategoriesController : BaseController
    {
		public ActionResult Show(int id = -1)
		{
			var cat = repository.Categories.SingleOrDefault(c => c.Id == id);
			if (cat == null)
			{
				return HttpNotFound();
			}

			var books = repository.Books.Where(b => b.CategoryId == id).ToArray();

			var vm = new CategoryViewModel();
			vm.Category = cat;
			vm.Books = books;

			return View(vm);
        }
    }
}