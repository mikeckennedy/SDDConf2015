using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_forms_starter.core.Models;
using mvc_forms_starter.ViewModels;

namespace mvc_forms_starter.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

		[HttpGet]
        public ActionResult AddBook()
        {
			var vm = new CreateBookViewModel();
			vm.CategoriesList =
				(from c in repository.Categories
				select new SelectListItem() {Text = c.Name, Value = c.Id.ToString()}).ToList();

            return View(vm);
        }

		[HttpPost]
       // public ActionResult AddBook(string bookTitle, string imageUrl, float price)
		public ActionResult AddBook(CreateBookViewModel vm)
		{
			if (!ModelState.IsValid)
			{
				vm.CategoriesList =
				(from c in repository.Categories
				 select new SelectListItem() { Text = c.Name, Value = c.Id.ToString() }).ToList();
				
				return View(vm);
			}
			Book dbBook = new Book();
			AutoMapper.Mapper.Map(vm, dbBook);

			repository.AddBook(dbBook, vm.CategoryId);

			return Redirect("/categories/show/" + vm.CategoryId);
		}
    }
}