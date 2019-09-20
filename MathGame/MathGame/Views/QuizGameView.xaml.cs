namespace MathGame.Views
{
    using Autofac;
    using MathGame.Data;
    using MathGame.ViewModels;
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    public partial class QuizGameView : UserControl
    {
        private QuizGameViewModel game;

        public QuizGameView()
        {
            InitializeComponent();

            this.DataContext =
                Bootstraper.Container.Resolve<QuizGameViewModel>();
            this.game = this.DataContext as QuizGameViewModel;
            this.FirstQuestion();
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
            option1.Content = this.game.CurrentOption1;
            option2.Content = this.game.CurrentOption2;
        }

        private void CurrentQuestion()
        {
            currQuestion.Text = this.game.CurrentQuestion;

            CurrentOptions();

            //numOfQuestion.Content = this.quiz.QuestionId;
            var tempQnum = this.game.QuestionId;
            if (tempQnum < QuizData.qaData.GetLength(0))
            {
                this.game.QuestionId++;
            }
        }

        private void FirstQuestion()
        {
            this.game.Timer.Start();
            CurrentQuestion();
            EnableRad();
            ResetRadSelection();
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            var selectedOption = (option1.IsChecked == true
                ? option1.Content 
                : option2.IsChecked == true 
                ? option2.Content 
                : MessageBox.Show("МОЛЯ, ИЗБЕРИ ЕДИН ОТГОВОР!")).ToString();

            
            this.game.StoreAnswer(selectedOption);
            var tempQ = this.game.QuestionId;
            if (tempQ >= QuizData.qaData.GetLength(0))
            {
                this.EndQuiz();
            }
            else
            {
                this.CurrentQuestion();
                this.EnableRad();
                this.ResetRadSelection();
            }
        }

        private void EndQuiz()
        {
            var game = DataContext as QuizGameViewModel;
            this.game.Timer.Stop();
            Window review = new ReviewView();
            review.Show();
            Window.GetWindow(this).Close();
        }

        private void ShowAnswer_Click(object sender, RoutedEventArgs e)
        {

            string answer = this.game.Quiz[this.game.QuestionId-1].CorrectAnswer;
            int numOfAnswer = answer == this.game.Quiz[this.game.QuestionId - 1].Answer1 ? 1 : 2;
            this.game.GameInfo.Penalize();
            switch (numOfAnswer)
            {
                case 1:
                    option1.Foreground = Brushes.Orange;
                    break;
                case 2:
                    option2.Foreground = Brushes.Orange;
                    break;
            }
            //this.DisableRad();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Window startScreen = new MainWindow();
            startScreen.Show();
            Window.GetWindow(this).Close();
        }

        private void Rules_Click(object sender, RoutedEventArgs e)
        {
            var gamename = nameof(QuizGameView);
            RulesView rules = new RulesView(gamename);
            rules.Show();
        }

    }
}
