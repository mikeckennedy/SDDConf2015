using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvc_forms_starter.core.Models;
using mvc_forms_starter.ViewModels;

namespace mvc_forms_starter.App_Start
{
	public static class AutomapperConfig
	{
		public static void Configure()
		{
			AutoMapper.Mapper.CreateMap<CreateBookViewModel, Book>();
		}
	}
}