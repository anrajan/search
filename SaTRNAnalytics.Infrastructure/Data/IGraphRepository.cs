using System;
using System.Collections.Generic;
using System.Text;
using Neo4jClient;

namespace SaTRNAnalytics.Infrastructure.Data
{
  public interface IGraphRepository
    {
        IGraphClient GetConnection();
    }
}
