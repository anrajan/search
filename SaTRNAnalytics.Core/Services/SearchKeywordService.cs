using System;
using System.Collections.Generic;
using System.Text;
using SaTRNAnalytics.Core.Entities;
using SaTRNAnalytics.Core.Interfaces;

namespace SaTRNAnalytics.Core.Services
{
    public class SearchKeywordService : ISearchKeywordService
    {
        private readonly ISearchKeywordRepository _searchKeywordRepository;

        public SearchKeywordService()
        {
        }
        public SearchKeywordService(ISearchKeywordRepository searchKeywordRepository)
        {
            _searchKeywordRepository = searchKeywordRepository;
        }

        public List<SearchKeyword> GetKeywordsByBemsId(int bemsID)
        {
            return _searchKeywordRepository.GetKeywords(bemsID);
        }

        public List<SearchKeyword> StoreKeywordByBemsId(UserSearchKeyword values)
        {
            return _searchKeywordRepository.StoreKeywords(values);
        }

    }
}
