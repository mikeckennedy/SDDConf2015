using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_forms_starter.ViewModels
{
	public class CreateBookViewModel
	{
		[Required] public string Name { get; set; }
		[Required] public string ImageUrl { get; set; }
		[Required] public float Price { get; set; }

		[Required] public int CategoryId { get; set; }
		public List<SelectListItem> CategoriesList { get; set; }
	}
}