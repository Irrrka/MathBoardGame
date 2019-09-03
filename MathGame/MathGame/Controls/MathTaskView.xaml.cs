using MathGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MathGame.Controls
{
    /// <summary>
    /// Interaction logic for MathTaskView.xaml
    /// </summary>
    public partial class MathTaskView : UserControl
    {
        public static readonly DependencyProperty MathTaskProperty =
               DependencyProperty.Register(
                     "Task",
                      typeof(MathTask),
                      typeof(MathTaskView));


        public MathTaskView()
        {
            InitializeComponent();
        }

        public MathTask Task
        {
            get
            {
                return (MathTask)GetValue(MathTaskProperty);
            }
            set
            {
                SetValue(MathTaskProperty, value);
            }
        }
    }
}
