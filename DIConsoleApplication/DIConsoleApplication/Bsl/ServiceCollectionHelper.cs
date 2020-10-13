using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIConsoleApplication.Bsl
{
    public class ServiceCollectionHelper
    {
        private static ServiceCollectionHelper _instance;
        private static readonly object ObjLocked = new object();
        private static ServiceProvider _servicePrivider;

        protected ServiceCollectionHelper()
        {
        }

        public static ServiceCollectionHelper Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (ObjLocked)
                    {
                        if (null == _instance)
                            _instance = new ServiceCollectionHelper();
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Register all service here
        /// </summary>
        public void RegisterService()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<INumberService, NumberService>();
            // Add more service here

            _servicePrivider = serviceCollection.BuildServiceProvider();
        }

        /// <summary>
        /// Method help get service from service collection
        /// </summary>
        /// <typeparam name="T">Service you want to get</typeparam>
        /// <returns></returns>
        public T GetService<T>()
        {
            return _servicePrivider.GetService<T>();
        }


        /// <summary>
        /// Dispose sevice collection
        /// </summary>
        public void Dispose()
        {
            if (_servicePrivider is IDisposable)
            {
                ((IDisposable)_servicePrivider).Dispose();
            }
        }

    }
}
