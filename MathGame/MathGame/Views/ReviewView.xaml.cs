using MathGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
namespace MathGame.Views
{
    public partial class ReviewView : Window
    {
        private readonly int lenght = QuizData.qaData.GetLength(0);
        private readonly List<string> missedQuestions;
        private Data.Image image;
        public ReviewView()
        {
            InitializeComponent();
            this.missedQuestions = new List<string>();
            this.GetMissedQuestions();
            this.Result = this.missedQuestions;
        }

        public string ImagePath
        {
            get
            {
                return this.image.Path;
            }
            set
            {
                this.ImagePath = value;
            }
        }
        public List<string> Result { get; private set; }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Window startScreen = new MainWindow();
            startScreen.Show();
            Window.GetWindow(this).Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void GetMissedQuestions()
        {
            int numOfMissedQuestions = 0;
            for (int i = 0; i < this.lenght; i++)
            {
                if (QuizData.qaData[i,3] != QuizData.qaData[i, 4])
                {
                    this.missedQuestions.Add(QuizData.qaData[i, 0]);
                    questions.Items.Add(QuizData.qaData[i, 0]);
                    numOfMissedQuestions++;
                }
            }

            resultText.Text = $"Правилни отговори {this.lenght - numOfMissedQuestions}/{this.lenght}";
            if (numOfMissedQuestions>0)
            {
                text.Text = "Грешни отговори на въпроси:";
            }
            this.Result = this.missedQuestions;

            if (numOfMissedQuestions==0)
            {
                this.image = new Data.Image { Path = "/MathGame;component/Resources/success_image.png" };
            }
        }
    }
}
