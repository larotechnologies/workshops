using System;
using Microsoft.Extensions.DependencyInjection;

namespace Larotech.Workshops.DependencyInjection.ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Step1(args);
            Step2(args);
            Step3(args);
            Step4(args);
        }

        #region Step1

        static IServiceProvider GetServiceProvider_Step1()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IGame, Backgammon>();

            return serviceCollection.BuildServiceProvider();
        }

        static void Step1(string[] args)
        {
            var provider = GetServiceProvider_Step1();

            var game = provider.GetRequiredService<IGame>();
        }

        #endregion

        #region Step2

        static IServiceProvider GetServiceProvider_Step2()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IGame, Backgammon>();
            serviceCollection.AddSingleton<IGame, Chess>();

            return serviceCollection.BuildServiceProvider();
        }

        static void Step2(string[] args)
        {
            var provider = GetServiceProvider_Step2();

            // will this will fail? :-)
            var game = provider.GetService<IGame>();
        }

        #endregion

        #region Step3

        static IServiceProvider GetServiceProvider_Step3()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<Backgammon>();
            serviceCollection.AddSingleton<Chess>();

            return serviceCollection.BuildServiceProvider();
        }

        static void Step3(string[] args)
        {
            var provider = GetServiceProvider_Step3();

            var backgammon = provider.GetService<Backgammon>();
            var chess = provider.GetService<Chess>();
        }

        #endregion

        #region Step4

        static IServiceProvider GetServiceProvider_Step4()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<Backgammon>();
            serviceCollection.AddSingleton<Chess>();

            return serviceCollection.BuildServiceProvider();
        }

        static void Step4(string[] args)
        {
            var provider = GetServiceProvider_Step4();

            var backgammon = provider.GetRequiredService<Backgammon>();
            var chess = provider.GetRequiredService<Chess>();

            // will this will fail? :-)
            var game1 = provider.GetService<IGame>();
            var game2 = provider.GetRequiredService<IGame>();
        }

        #endregion
    }
}
