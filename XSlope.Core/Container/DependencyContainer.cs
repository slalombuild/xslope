using System;
using System.Collections.Generic;
using Ninject;

namespace XSlope.Core.Container
{
    public static class DependencyContainer
    {
        static IKernel _kernel;

        public static void Build(List<BaseContainerModule> modules)
        {
            var settings = new NinjectSettings
            {
                InjectNonPublic = true,
                InjectParentPrivateProperties = true
            };

            var kernel = new StandardKernel(settings, modules.ToArray());
            Build(kernel);
        }

        public static void Build(IKernel kernel)
        {
            _kernel = kernel;
        }

        public static T Get<T>(string name = null)
        {
            if (_kernel == null)
            {
                throw new NullReferenceException("IKernel Container is null");
            }

            return _kernel.Get<T>(name);
        }

        public static void Inject(object obj)
        {
            if (_kernel == null)
            {
                throw new NullReferenceException("IKernel Container is null");
            }

            _kernel.Inject(obj);
        }

        public static void BindInstance<T>(T obj)
        {
            if (_kernel == null)
            {
                throw new NullReferenceException("IKernel Container is null");
            }

            _kernel.Bind<T>().ToConstant(obj);
        }
    }
}
