using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Kennedy;

namespace FirstCSharp
{
	class Car
	{
		public ObjectId Id { get; set; }
		public string Type { get; set; }
		public string Model { get; set; }
		public List<Color> Colors { get; set; }

		public Car()
		{
			this.Colors = new List<Color>();
		}
	}

	class Color
	{
		public string Name { get; set; }
		public float Price { get; set; }
	}

	class Mongo : MongoDbDataContext
	{
		public Mongo() : base("FirstCSharp")
		{
		}

		public IQueryable<Car> Cars
		{
			get { return this.GetCollection<Car>(); }
		}
	}
}
