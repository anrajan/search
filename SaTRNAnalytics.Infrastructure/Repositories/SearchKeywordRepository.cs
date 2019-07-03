using System.Collections.Generic;
using System.Linq;
using SaTRNAnalytics.Core.Entities;
using SaTRNAnalytics.Core.Interfaces;
using SaTRNAnalytics.Infrastructure.Data;

namespace SaTRNAnalytics.Infrastructure.Repositories
{
    public class SearchKeywordRepository : ISearchKeywordRepository
    {
        private IGraphRepository _graphRepository;
        public SearchKeywordRepository(IGraphRepository graphRepository)
        {
            _graphRepository = graphRepository;
        }

        public List<SearchKeyword> GetKeywords(int bemsID)
        {
            using (var _provider = _graphRepository.GetConnection())
            {
                var query = _provider.Cypher.Match("(n:User)-[]-(m:SearchKeyword)")
                   .Where("n.Bemsid = {id}")
                   .WithParam("id", bemsID.ToString())
                   .Return(m => m.As<SearchKeyword>());              
                return query.Results.ToList();
            }
        }

        public List<SearchKeyword> StoreKeywords(UserSearchKeyword value)
        {
            using (var _provider = _graphRepository.GetConnection())
            {
                var query = _provider.Cypher.Merge("(c: User { Bemsid: {id} })")
                   .Merge("(d: SearchKeyword { Keyword: {keyword} })")
                   .WithParam("id", value.BemsID)                 
                   .WithParam("keyword", value.ProductName)
                   .Create("(c)-[:SEARCHED]->(d)")
                   .Return<SearchKeyword>("c");

                return query.Results.ToList();
            }
        }

    }
}
