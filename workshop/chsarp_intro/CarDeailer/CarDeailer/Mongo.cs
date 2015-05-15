using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Kennedy;

namespace CarDeailer
{
	class Mongo : MongoDbDataContext
	{
		public Mongo() : base("WorkshopCars")
		{
		}

		public IQueryable<Car> Cars
		{
			get { return this.GetCollection<Car>(); }
		}

		public MongoCollection<Car> CarsCollection
		{
			get { return this.GetMongoCollection<Car>(); }
		}
	}

	[BsonIgnoreExtraElements]
	public class Car : ISupportInitialize
	{
		public ObjectId Id { get; set; }

		public string Model { get; set; }
		public string Type { get; set; }

		//public float Price { get; set; }
		public int IntPrice { get; set; }
		
		[BsonIgnoreIfNull]
		public Color Color { get; set; }
		//public Owner Owner { get; set; }

		public List<WorkHistory> History { get; set; }

		//[BsonExtraElements]
		//public BsonDocument AdditionalData { get; set; }

		public Car()
		{
			this.History = new List<WorkHistory>();
			//this.Price = 2.7771f*(new Random().Next(0, 100));
		}

		public void BeginInit()
		{
		}

		public void EndInit()
		{
			this.History.ForEach(h => h.Car = this);
		}
	}

	public class SuperCar : Car
	{
		public int NumberOfTurbos { get; set; }
	}

	public class WorkHistory
	{
		public string Desc { get; set; }
		public string Location { get; set; }
		public double Price { get; set; }

		[BsonIgnore]
		public Car Car { get; set; }
	}

	public class Color
	{
		public string Name { get; set; }
		public string SerialNumber { get; set; }

		//[BsonExtraElements]
		//public BsonDocument AdditionalData { get; set; }
	}

	public class Owner
	{
		public string Name { get; set; }
	}
}
