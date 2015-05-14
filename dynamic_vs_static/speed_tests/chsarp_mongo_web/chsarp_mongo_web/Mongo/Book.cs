using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace chsarp_mongo_web.Mongo
{

	public class Book
	{
		public ObjectId Id { get; set; }
		public string ISBN { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public DateTime Published { get; set; }
		public ObjectId Publisher { get; set; }
		public List<Imageurl> ImageUrls { get; set; }
		public List<Rating> Ratings { get; set; }

		public Book()
		{
			ImageUrls = new List<Imageurl>();
			Ratings = new List<Rating>();
		}
	}

	public class Imageurl
	{
		public int Size { get; set; }
		public string Url { get; set; }
	}

	public class Rating
	{
		public ObjectId UserId { get; set; }
		public int Value { get; set; }
	}


}