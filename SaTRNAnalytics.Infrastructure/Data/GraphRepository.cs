using System;
using System.Collections.Generic;
using System.Text;
using Neo4jClient;
using Microsoft.Extensions.Options;

namespace SaTRNAnalytics.Infrastructure.Data
{
    public class GraphRepository : IGraphRepository, IDisposable
    {
        private readonly IOptions<ServerConfig> _apiConfig;
        private IGraphClient _provider = null;
        public void Dispose()
        {
            if (_provider != null && _provider.IsConnected == true)
            {
                _provider.Dispose();
            }
        }
        public GraphRepository(IOptions<ServerConfig> apiConfig)
        {
            _apiConfig = apiConfig;
        }

        public IGraphClient GetConnection()
        {
            _provider = new GraphClient(new Uri(_apiConfig.Value.Url), _apiConfig.Value.UserId, _apiConfig.Value.Password);
            _provider.Connect();
            return _provider;
        }
    }
}
