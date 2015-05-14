using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chsarp_mongo_web.Mongo
{
	public class MongoContext : MongoDB.Kennedy.MongoDbDataContext
	{
		public MongoContext(string databaseName = "BookStore", string serverName = "localhost") :
			base(databaseName, serverName)
		{
		}

		public IQueryable<Book> Books { get { return base.GetCollection<Book>(); } }
	}
}