namespace MathGame.Views
{
    using Autofac;
    using MathGame.ViewModels;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    public partial class QuizGameView : UserControl
    {
        public QuizGameView()
        {
                InitializeComponent();
                this.DataContext =
                    Bootstraper.Container.Resolve<QuizGameViewModel>();

            //this.FirstQuestion();
        }

        private void EnableRad()
        {
            option1.IsEnabled = true;
            option2.IsEnabled = true;
        }

        private void DisableRad()
        {
            option1.IsEnabled = false;
            option2.IsEnabled = false;
        }

        private void ResetRadSelection()
        {
            option1.IsChecked = false;
            option2.IsChecked = false;

            option1.Foreground = Brushes.Aquamarine;
            option2.Foreground = Brushes.Aquamarine;
        }

        private void CurrentOptions()
        {
            option1.Content = "Маринко";
            option2.Content = "Явор";
        }

        private void CurrentQuestion()
        {
            //var currQuestion = this.DataContext.Quiz[this.QuestionId].Question;
            //currQuestion.Text = currQ;

            CurrentOptions();

            numOfQuestion.Content = 1;
        }

        private void PlayAgain(object sender, RoutedEventArgs e)
        {
            var game = DataContext as QuizGameViewModel;
            game.Restart();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var game = DataContext as QuizGameViewModel;
            var button = sender as Button;
            //game.ClickedSlide(button.DataContext);
        }

        private void FirstQuestion()
        {
            CurrentQuestion();
            EnableRad();
            ResetRadSelection();
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            //StoreAnswer();

            //determines whether or not user has started the quiz by clicking the next button
            //if (quizStart != true)
            //{
            //    Timer();
            //    quizStart = true;
            //}

            //determines if the user has reached the end of the quiz, else goes to next question
            //if (intQuest > QuesAnsw.strQuestions.GetUpperBound(0))
            //{
            //    endquiz();
            //}
            //else
            //{
                CurrentQuestion();
                EnableRad();
                ResetRadSelection();
            //}
        }

        private void ShowAnswer_Click(object sender, RoutedEventArgs e)
        {
            //var game = DataContext as QuestionCollectionViewModel;
            //game.qui();

            int numOdAnswer = 2;
            switch (numOdAnswer)
            {
                case 1:
                    option1.Foreground = Brushes.Orange;
                    break;
                case 2:
                    option2.Foreground = Brushes.Orange;
                    break;
            }
            DisableRad();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Window startScreen = new MainWindow();
            startScreen.Show();
            Window.GetWindow(this).Close();
        }
    }
}
