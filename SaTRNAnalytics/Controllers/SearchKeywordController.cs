using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaTRNAnalytics.Core.Entities;
using SaTRNAnalytics.Core.Interfaces;

namespace SaTRNAnalytics.Controllers
{
    public class SearchKeywordController : BaseApiController
    {
        private readonly ISearchKeywordService _searchKeywordService;
        private readonly ILogger<SearchKeywordController> _logger;

        public SearchKeywordController(ISearchKeywordService searchKeywordService, ILogger<SearchKeywordController> logger)
        {
            _searchKeywordService = searchKeywordService;
            _logger = logger;
        }

        /// <summary>
        /// Get Search keywords for BemsID.
        /// </summary>
        /// <param name="id"></param> 
        /// <response code="201">Returns the keywords</response>
        /// <response code="400">If the item is null</response>           
        [HttpGet("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<List<SearchKeyword>> Get(int id)
        {
            _logger.LogInformation("Fetching keywords for: " + id);
            return _searchKeywordService.GetKeywordsByBemsId(id);            
        }
        
        /// <summary>
        /// Store Search keyword with User details.
        /// </summary>
        /// <param name="values"></param> 
        /// <response code="201">Returns void</response>
        /// <response code="400">If the item is null</response>   
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public void Post([FromBody] UserSearchKeyword values)
        {
            _logger.LogDebug("enter post action");
            _searchKeywordService.StoreKeywordByBemsId(values);
        }
    }
}
