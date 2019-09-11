using MathGame.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        public static readonly DependencyProperty DragInitCommandProperty =
        DependencyProperty.Register(
              "DragInitCommand",
               typeof(ICommand),
               typeof(MathTaskView));

        public static readonly DependencyProperty DragOverCommandProperty =
        DependencyProperty.Register(
              "DragOverCommand",
               typeof(ICommand),
               typeof(MathTaskView));

        public MathTaskView()
        {
            InitializeComponent();
        }

        public MathTask MathTask
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

        public ICommand DragInitCommand
        {
            get
            {
                return (ICommand)GetValue(DragInitCommandProperty);
            }
            set
            {
                SetValue(DragInitCommandProperty, value);
            }
        }

        public ICommand DragOverCommand
        {
            get
            {
                return (ICommand)GetValue(DragOverCommandProperty);
            }
            set
            {
                SetValue(DragOverCommandProperty, value);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(MathTask.ToString());
        }

        private void DragInitHandler(object sender, MouseButtonEventArgs e)
        {
            DragInitCommand.Execute(MathTask);
        }

        private void DragOverHandler(object sender, MouseButtonEventArgs e)
        {
            DragOverCommand.Execute(MathTask);
        }
    }
}
