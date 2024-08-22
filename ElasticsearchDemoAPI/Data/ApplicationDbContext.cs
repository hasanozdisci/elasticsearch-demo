using ElasticsearchDemoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ElasticsearchDemoAPI.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Article> Articles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Seed data
			modelBuilder.Entity<Article>().HasData(
				new Article { Id = 1, Title = "Learn Elasticsearch", Content = "Elasticsearch is a distributed search engine." },
				new Article { Id = 2, Title = "Elasticsearch Tutorial", Content = "This is a tutorial on how to use Elasticsearch." },
				new Article { Id = 3, Title = "EF Core with Elasticsearch", Content = "This example shows how to use EF Core with Elasticsearch." }
			);
		}
	}
}
