using ElasticsearchDemoAPI.Models;

namespace ElasticsearchDemoAPI.Services.Interfaces
{
	public interface ISearchService
	{
		Task<IEnumerable<Article>> SearchAsync(string query);
		Task IndexArticleAsync(Article article);
		Task UpdateArticleAsync(Article article);
		Task DeleteArticleAsync(int id);
	}
}
