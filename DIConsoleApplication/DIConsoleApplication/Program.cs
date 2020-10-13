using DIConsoleApplication.Bsl;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DIConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Way 1 - Basic code
            // Step1: setup our DI
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<INumberService, NumberService>();
            //TODO: Add more service here....

            //Step 2: get service 
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var numberService = serviceProvider.GetService<INumberService>();

            var lstNumber = numberService.GetEvenNumber(1, 15);
            if(lstNumber != null && lstNumber.Any())
            {
                int stt = 0;
                foreach(int number in lstNumber)
                {
                    stt++;
                    Console.WriteLine(string.Format("Value of item {0} is: {1}", stt, number));
                }
            }

            // Step 3: dispose & realse all service from service collection
            if (serviceProvider is IDisposable)
            {
                ((IDisposable)serviceProvider).Dispose();
            }

            #endregion

            #region Way 2 - Using Singleton pattern to call service collection from any where

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("------------------------------------------------");

            ServiceCollectionHelper.Instance.RegisterService();
            var numberService2 = ServiceCollectionHelper.Instance.GetService<INumberService>();

            var lstNumber2 = numberService.GetEvenNumber(1, 15);
            if (lstNumber2 != null && lstNumber2.Any())
            {
                int stt = 0;
                foreach (int number in lstNumber2)
                {
                    stt++;
                    Console.WriteLine(string.Format("Value of item {0} is: {1}", stt, number));
                }
            }

            ServiceCollectionHelper.Instance.Dispose();
            #endregion
        }
    }
}
