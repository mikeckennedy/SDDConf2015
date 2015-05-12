using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoBlog
{
	[BsonIgnoreExtraElements]
	public class Post : ISupportInitialize
	{
		public ObjectId Id { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public DateTime Created { get; set; }
		public string Permalink { get; set; }
		//public List<Comment> Comments { get; set; }
		public List<Comment> Likes { get; set; } 


		//[BsonExtraElements]
		//public BsonDocument AdditionalData { get; set; }

		public Post()
		{
			this.Created = DateTime.UtcNow;
			this.Likes = new List<Comment>();
		}

		public void BeginInit()
		{
		}

		public void EndInit()
		{
			foreach (var l in Likes)
			{
				l.Post = this;
			}
		}
	}

	public class Comment 
	{
		public string UserName { get; set; }
		public string Text { get; set; }
		public DateTime Created { get; set; }
		[BsonIgnore]
		public Post Post { get; set; }

		public Comment()
		{
			this.Created = DateTime.UtcNow;
		}
	}
}
