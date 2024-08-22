using AutoMapper;
using ElasticsearchDemoAPI.Models;

namespace ElasticsearchDemoAPI.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Article, ArticleDTO>().ReverseMap();
		}
	}
}
