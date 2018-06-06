using System;
using XSlope.Core.ViewModels;
using STARTER_APP.Core.Resources;
using XSlope.Core.Container;

namespace STARTER_APP.Core.ViewModels
{
    public class HelloWorldViewModel : BaseViewModel
    {
        public static HelloWorldViewModel NewInstance() => DependencyContainer.Get<HelloWorldViewModel>();

        public string Title => LocalizedStrings.HelloWorld_Title;
        public string GettingStartedText => LocalizedStrings.HelloWorld_GettingStarted;
    }
}
