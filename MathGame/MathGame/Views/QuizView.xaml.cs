using Autofac;
using MathGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MathGame.Views
{
    using System.Windows.Controls;
    /// <summary>
    /// Interaction logic for QuizView.xaml
    /// </summary>
    public partial class QuizView : Page
    {
        public QuizView()
        {
            InitializeComponent();
            this.DataContext =
                Bootstraper.Container.Resolve<QuestionViewModel>();
        }
    }
}
