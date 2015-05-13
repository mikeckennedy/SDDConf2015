using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvc_forms_starter.core.Models;

namespace mvc_forms_starter.ViewModels
{
	public class CategoryViewModel
	{
		public Category Category { get; set; }
		public Book[] Books { get; set; }
	}
}