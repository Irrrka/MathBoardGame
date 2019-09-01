using Autofac;
using MathGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

            builder.RegisterType<MultiplicationBy2ViewModel>();

            Container = builder.Build();
        }
    }
}
