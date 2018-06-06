using Xunit;
using STARTER_APP.Core.ViewModels;

namespace STARTER_APP.Core.Tests.ViewModels
{
    public class HelloWorldViewModelTests : BaseTest
    {
        [Fact]
        public void TestProperties()
        {
            var viewModel = HelloWorldViewModel.NewInstance();

            Assert.Equal("Hello World", viewModel.Title);
            Assert.Equal("To get started, use the rename script to change the solution and project names.", viewModel.GettingStartedText);
        }
    }
}
