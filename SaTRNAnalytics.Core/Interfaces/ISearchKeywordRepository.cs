using System;
using System.Collections.Generic;
using System.Text;
using SaTRNAnalytics.Core.Entities;

namespace SaTRNAnalytics.Core.Interfaces
{
   public interface ISearchKeywordRepository
    {
        List<SearchKeyword> GetKeywords(int bemsID);
        List<SearchKeyword> StoreKeywords(UserSearchKeyword values);
    }
}
