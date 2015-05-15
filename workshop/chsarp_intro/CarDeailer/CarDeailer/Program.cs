using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Driver.Builders;

namespace CarDeailer
{
	class Program
	{
		static void Main(string[] args)
		{
			RefreshSchema();
			//AddData();
			
			QueryData();
			//AddHistory();
			Projection();
		}

		private static void Projection()
		{
			var mongo = new Mongo();
			
			//mongo.Db.GridFS.Upload("/car/27/thumbnail.png", "data");

			//if (mongo.Db.GridFS.Exists("/car/27/thumbnail.png"))
			//{
			//	return "/images/gray_car.png";
			//}

			//return new FileResult("thumb27.png", mongo.Db.GridFS.Download("/car/27/thumbnail.png"), "img/png")

			var query = Query<Car>.Where(c => c.History.Any());
			var data = mongo.CarsCollection
				.Find(query)
				.SetFields("Model")
				.AsEnumerable()
				.Select(c => new {Id = c.Id, Model=c.Model});
			foreach (var c in data)
			{
				Console.WriteLine(c);
			}
		}

		private static void RefreshSchema()
		{
			var mongo = new Mongo();
			foreach (var car in mongo.Cars)
			{
				mongo.Save(car);
			}
		}

		private static void AddHistory()
		{
			var mongo = new Mongo();
			var tesla = mongo.Cars.Single(c => c.Type == "Tesla");
			tesla.History.Add(new WorkHistory() { Desc = "Change eletric brushes", Location = "UK", Price = 72730 });
			tesla.History.Add(new WorkHistory() { Desc = "Dust removal", Location = "UK", Price = 700 });
			tesla.History.Add(new WorkHistory() { Car = tesla, Desc = "Polish", Location = "USA", Price = 10000 });

			mongo.Save(tesla);
		}

		private static void QueryData()
		{
			var mongo = new Mongo();

			Console.WriteLine("All cars");
			var cars = mongo.Cars.OrderBy(c => c.Model).ToArray();
			foreach (var car in cars)
			{
				Console.WriteLine(car.Model + " " + car.Type);
			}
			Console.WriteLine();

			Console.WriteLine("Expensive work");
			var expensiveWork =
				from c in mongo.Cars
				where c.History.Any(h => h.Price > 500)
				select c;

			Console.WriteLine("query is: " + expensiveWork.ToMongoQueryText());

			foreach (var car in expensiveWork)
			{
				Console.WriteLine(car.Model + " " + car.Type);
				Console.WriteLine("Work:");
				foreach (var h in car.History)
				{
					Console.WriteLine("  * {0} for {1} (from {2})",
						h.Desc, h.Price, h.Car.Model);
				}
				Console.WriteLine();
			}

			Console.WriteLine("Some work");
			var work =
				(from c in mongo.Cars
				where c.History.Any()
				select c)
				.AsEnumerable()
				.SelectMany(c => c.History);

			foreach (var h in work)
			{
				Console.WriteLine("  * {0} for {1}", h.Desc, h.Price);
				Console.WriteLine();
			}
		}

		private static void AddData()
		{
			var mongo = new Mongo();

			var car = new Car();
			car.Color = new Color() { Name = "Light Blue", SerialNumber = "o09345890358" };
			car.Model = "Model S";
			car.Type = "Tesla";

			mongo.Save(car);

			car = new Car();
			car.Color = new Color() { Name = "Yellow", SerialNumber = "o3459834598" };
			car.Model = "Esprit";
			car.Type = "Lotus";

			mongo.Save(car);

			//var car = new SuperCar();
			//car.Color = new Color() { Name = "Yellow", SerialNumber = "1" };
			//car.NumberOfTurbos = 4;
			//car.Model = "380";
			//car.Type = "Ferrari";

			//mongo.Save((Car)car);
		}
	}
}
