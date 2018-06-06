using System;
using XSlope.Core.Providers.Interfaces;

namespace XSlope.Core.Managers.Interfaces
{
    public interface ICacheManager
    {
        ICacheProvider AppCache { get; }
    }
}
