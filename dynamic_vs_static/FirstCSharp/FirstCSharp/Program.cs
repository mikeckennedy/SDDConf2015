using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCSharp
{
	class Program
	{
		static void Main(string[] args)
		{
			//AddData();
			QueryData();
		}

		private static void QueryData()
		{
			var mongo = new Mongo();
			var cars =
				from c in mongo.Cars
				where c.Colors.Any(cl => cl.Price > 12)
				select c;

			foreach (var car in cars)
			{
				Console.WriteLine(car.Model);
			}
		}

		private static void AddData()
		{
			var mongo = new Mongo();

			var car1 = new Car()
			{
				Model = "Model S",
				Type = "Tesla"
			};
			car1.Colors.Add(new Color() {Name = "White", Price = 10.5f});
			car1.Colors.Add(new Color() {Name = "Black", Price = 9.5f});

			mongo.Save(car1);

			car1 = new Car()
			{
				Model = "Esprite",
				Type = "Lotus"
			};
			car1.Colors.Add(new Color() {Name = "Yellow", Price = 15.5f});

			mongo.Save(car1);
		}
	}
}
