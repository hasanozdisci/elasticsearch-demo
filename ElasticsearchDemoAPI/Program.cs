

using ElasticsearchDemoAPI.Data;
using ElasticsearchDemoAPI.Services;
using ElasticsearchDemoAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Nest;

namespace ElasticsearchDemoAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			// configure db context with connection string in appsettings.json
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});

			// configure Elasticsearch
			builder.Services.AddSingleton<IElasticClient>(sp =>
			{
				var settings = new ConnectionSettings(new Uri(builder.Configuration["Elasticsearch:Url"]))
							   .DefaultIndex("articles");
				return new ElasticClient(settings);
			});
			builder.Services.AddScoped<ISearchService, ElasticsearchService>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
