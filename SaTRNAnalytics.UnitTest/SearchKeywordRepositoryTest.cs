using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Neo4jClient;
using NUnit.Framework;
using SaTRNAnalytics.Core.Entities;
using SaTRNAnalytics.Core.Interfaces;
using SaTRNAnalytics.Infrastructure.Data;

namespace SaTRNAnalytics.UnitTest
{
    [TestFixture]
    class SearchKeywordRepositoryTest
    {
        readonly int testBemsId = 3058371;
        private readonly Mock<IGraphRepository> storeRepositoryMock;
        private readonly Mock<IGraphClient> graphClientMock;
        private readonly Mock<ISearchKeywordRepository> searchRepositoryMock;

        public SearchKeywordRepositoryTest()
        {
            storeRepositoryMock = new Mock<IGraphRepository>();
            graphClientMock = new Mock<IGraphClient>();
            searchRepositoryMock = new Mock<ISearchKeywordRepository>();
        }

        [Test]
        public void ShouldReturnGetKeywords()
        {
            var testSearchKeywordData = new List<SearchKeyword>() { new SearchKeyword() { IdentityGuid = "12", Keyword = "azure" } };
            searchRepositoryMock.Setup(a => a.GetKeywords(testBemsId)).Returns(testSearchKeywordData);
            var ret = searchRepositoryMock.Object.GetKeywords(testBemsId);          

            Assert.AreEqual(ret.Count, "should return 1 keyword");
        }
    }
}
