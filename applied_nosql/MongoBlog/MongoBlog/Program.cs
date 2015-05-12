using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;

namespace MongoBlog
{
	class Program
	{
		static void Main(string[] args)
		{
			//ResaveAllPosts();
			//AddData();
			FindData();
		}

		private static void ResaveAllPosts()
		{
			var mongo = new Mongo();
			foreach (var p in mongo.Posts)
			{
				mongo.Save(p);
			}
		}

		private static void FindData()
		{
			var mongo = new Mongo();

			var markCommentedPosts =
				from p in mongo.Posts
				where p.Likes.Any(c => c.UserName == "mark")
				select p;

			Console.WriteLine("We'll run: " + markCommentedPosts.ToMongoQueryText());

			Console.WriteLine("Matching posts:");
			foreach (var post in markCommentedPosts)
			{
				Console.WriteLine("Post: " +post.Title);
				foreach (var c in post.Likes)
				{
					Console.WriteLine("\t * {0} says {1}", c.UserName, c.Text);
					Console.WriteLine("\t   Parent post: {0}", c.Post.Title);
				}
			}

		}

		private static void AddData()
		{
			var mongo = new Mongo();

			var post = new Post();
			Console.Write("Enter title: ");
			post.Title = Console.ReadLine();
			Console.Write("Enter text: ");
			post.Text = Console.ReadLine();

			post.Likes.Add(new Comment() { Post=post, Text = "This was cool!", UserName = "mark" });
			post.Likes.Add(new Comment() { Post = post, Text = "Buy my handbag: http://hackers.org", UserName = "jeff" });

			mongo.Save(post);
		}
	}
}
