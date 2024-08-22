using ElasticsearchDemoAPI.Models;
using ElasticsearchDemoAPI.Services.Interfaces;
using Nest;

namespace ElasticsearchDemoAPI.Services
{
	public class ElasticsearchService : ISearchService
	{
		private readonly IElasticClient _elasticClient;

		public ElasticsearchService(IElasticClient elasticClient)
		{
			_elasticClient = elasticClient;
		}

		public async Task<IEnumerable<Article>> SearchAsync(string query)
		{
			var searchResponse = await _elasticClient.SearchAsync<Article>(s => s
				.Query(q => q
					.MatchPhrasePrefix(m => m
						.Field(f => f.Content)
						.Field(f => f.Title)
						.Query(query)
						.Analyzer("standard")
					)
				)
			);
			return searchResponse.Documents;
		}

		public async Task IndexArticleAsync(Article article)
		{
			var response = await _elasticClient.IndexDocumentAsync(article);
		}

		public async Task UpdateArticleAsync(Article article)
		{
			var response = await _elasticClient.UpdateAsync<Article>(article.Id, u => u
				.Index("articles")
				.Doc(article) // The updated article document
			);
		}

		public async Task DeleteArticleAsync(int id)
		{
			var response = await _elasticClient.DeleteAsync<Article>(id, d => d
				.Index("articles")
			);
		}
	}

}
