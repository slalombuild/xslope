using System;
using Moq;
using Ninject;
using Ninject.Infrastructure;
using Ninject.MockingKernel.Moq;
using XSlope.Core.Container;
using XSlope.Core.Managers.Interfaces;
using XSlope.Core.Providers.Interfaces;
using XSlope.Core.ViewModels;
using Xunit;

namespace XSlope.Core.Tests
{
    [Collection("Injected test collection")]
    public abstract class BaseTest
    {
        readonly MoqMockingKernel _mockKernel;

        protected BaseTest()
        {
            _mockKernel = new MockKernel();
            DependencyContainer.Build(_mockKernel);

            // Ensure any usages of GetMock<ICacheProvider> will return the mock
            // that is setup on injected ICacheManager.AppCache
            var mockCacheManager = GetMock<ICacheManager>();
            var mockSessionCacheProvider = GetMock<ICacheProvider>();
            mockCacheManager.SetupGet(m => m.AppCache).Returns(mockSessionCacheProvider.Object);
        }

        protected Mock<T> GetMock<T>() where T : class
        {
            var mock = _mockKernel.GetMock<T>();
            mock.SetupAllProperties();
            return mock;
        }

        protected T Get<T>() where T : class
        {
            return _mockKernel.Get<T>();
        }
    }

    class MockKernel : MoqMockingKernel
    {
        protected override Ninject.Activation.IContext CreateContext(Ninject.Activation.IRequest request, Ninject.Planning.Bindings.IBinding binding)
        {
            var isBaseViewModel = binding.Service.IsSubclassOf(typeof(BaseViewModel));
            binding.ScopeCallback = isBaseViewModel ?
                StandardScopeCallbacks.Transient :
                StandardScopeCallbacks.Singleton;
            return base.CreateContext(request, binding);
        }
    }
}
