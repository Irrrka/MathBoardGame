using Autofac;
using MathGame.Services;
using MathGame.Services.Contracts;
using MathGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    public static class Bootstraper
    {
        public static IContainer Container { get; set; }
        public static void Init()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
               .Where(t => t.Name.EndsWith("ViewModel"))
               .AsSelf();

            Container = builder.Build();
        }
    }
}
