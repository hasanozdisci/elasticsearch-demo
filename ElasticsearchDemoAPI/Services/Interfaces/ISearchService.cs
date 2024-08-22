using ElasticsearchDemoAPI.Models;

namespace ElasticsearchDemoAPI.Services.Interfaces
{
	public interface ISearchService
	{
		Task<IEnumerable<ArticleDTO>> SearchAsync(string query);
		Task IndexArticleAsync(ArticleDTO article);
		Task UpdateArticleAsync(ArticleDTO article);
		Task DeleteArticleAsync(int id);
	}
}
