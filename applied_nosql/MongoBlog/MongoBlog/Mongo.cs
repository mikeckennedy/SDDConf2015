using System.Linq;
using MongoDB.Bson.IO;
using MongoDB.Kennedy;

namespace MongoBlog
{
	public class Mongo : MongoDbDataContext
	{
		public Mongo() : base("Sdd2015Blog")
		{
		}

		public IQueryable<Post> Posts {
			get { return this.GetCollection<Post>(); }
		}
	}
}