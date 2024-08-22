using AutoMapper;
using ElasticsearchDemoAPI.Models;
using ElasticsearchDemoAPI.Services.Interfaces;
using Nest;

namespace ElasticsearchDemoAPI.Services
{
	public class ElasticsearchService : ISearchService
	{
		private readonly IElasticClient _elasticClient;
		private readonly IMapper _mapper;

		public ElasticsearchService(IElasticClient elasticClient, IMapper mapper)
		{
			_elasticClient = elasticClient;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ArticleDTO>> SearchAsync(string query)
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

			return searchResponse.Documents.Select(d => _mapper.Map<ArticleDTO>(d));
		}

		public async Task IndexArticleAsync(ArticleDTO dto)
		{
			var article = _mapper.Map<Article>(dto);
			await _elasticClient.IndexAsync(article, i => i
				.Index("articles")
			);
		}

		public async Task UpdateArticleAsync(ArticleDTO dto)
		{
			var article = _mapper.Map<Article>(dto);
			await _elasticClient.UpdateAsync<Article>(article.Id, u => u
				.Index("articles")
				.Doc(article)
			);

		}

		public async Task DeleteArticleAsync(int id)
		{
			await _elasticClient.DeleteAsync<Article>(id, d => d
				.Index("articles")
			);
		}
	}

}
