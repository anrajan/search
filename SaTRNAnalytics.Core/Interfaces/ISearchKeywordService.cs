using System;
using System.Collections.Generic;
using System.Text;
using SaTRNAnalytics.Core.Entities;

namespace SaTRNAnalytics.Core.Interfaces
{
   public interface ISearchKeywordService
    {
        List<SearchKeyword> GetKeywordsByBemsId(int bemsID);
        List<SearchKeyword> StoreKeywordByBemsId(UserSearchKeyword values);
    }
}
