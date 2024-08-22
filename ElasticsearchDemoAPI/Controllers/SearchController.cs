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

		[HttpPost]
		public async Task<IActionResult> AddArticle([FromBody] ArticleDTO articleDTO)
		{
			await _searchService.IndexArticleAsync(articleDTO);
			return Ok("Article indexed successfully");
		}

		[HttpGet("search/{query}")]
		public async Task<IActionResult> SearchArticles(string query)
		{
			var articles = await _searchService.SearchAsync(query);
			return Ok(articles);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateArticle(int id, [FromBody] ArticleDTO articleDTO)
		{
			articleDTO.Id = id;
			await _searchService.UpdateArticleAsync(articleDTO);
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
