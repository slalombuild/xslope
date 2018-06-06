using Moq;
using Ninject;
using Ninject.MockingKernel.Moq;
using XSlope.Core.Container;
using Xunit;

namespace STARTER_APP.Core.Tests
{
    [Collection("Injected tests")]
    public abstract class BaseTest
    {
        protected MoqMockingKernel _mockKernel;

        protected BaseTest()
        {
            _mockKernel = new MoqMockingKernel();
            DependencyContainer.Build(_mockKernel);
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
}
