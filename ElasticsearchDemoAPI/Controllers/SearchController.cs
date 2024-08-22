using ElasticsearchDemoAPI.Models;
using ElasticsearchDemoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElasticsearchDemoAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SearchController : ControllerBase
	{
		private readonly ISearchService _searchService;

		public SearchController(ISearchService searchService)
		{
			_searchService = searchService;
		}

		[HttpGet("{query}")]
		public async Task<IActionResult> Search(string query)
		{
			var results = await _searchService.SearchAsync(query);
			return Ok(results);
		}

		[HttpPost]
		public async Task<IActionResult> Index([FromBody] Article article)
		{
			await _searchService.IndexArticleAsync(article);
			return Ok();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateArticle(int id, [FromBody] Article article)
		{
			article.Id = id; // Ensure the article ID is set correctly
			await _searchService.UpdateArticleAsync(article);
			return Ok("Article updated successfully");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteArticle(int id)
		{
			await _searchService.DeleteArticleAsync(id);
			return Ok("Article deleted successfully");
		}
	}
}
