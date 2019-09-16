using Autofac;
using MathGame.Services.Contracts;
using MathGame.ViewModels.HangmanGame;
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

namespace MathGame.Views
{
    /// <summary>
    /// Interaction logic for HangmanGameView.xaml
    /// </summary>
    public partial class HangmanGameView : UserControl
    {
        private HangmanGameViewModel game;
        private List<Button> buttons;
        private List<Label> labels;
        

        public HangmanGameView()
        {
            InitializeComponent();
            this.DataContext =
                Bootstraper.Container.Resolve<HangmanGameViewModel>();
            this.labels = new List<Label>();
            this.buttons = new List<Button>();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            this.game.Restart();
            //this.game.StageImage.Path = game.GetStageImage();
            this.labels.Clear();
            this.buttons.Clear();

            //this.CreateStage();
        }

        

        private void ShowAnswer_Click(object sender, RoutedEventArgs e)
        {
            t
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Letter_Click(object sender, RoutedEventArgs e)
        {
            int[] temp = this.game.Hangman.TakeCharachter((sender as Button).Content.ToString()[0]);

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == 1)
                {
                    this.labels[i].Content = this.game.Hangman.Word[i];
                }
            }

            this.game.Hangman.StageImage.Path = this.game.Hangman.GetStageImage().Path;

            if (this.labels.Count(l => l.Content == null) == 0)
            {
                this.game.GameInfo.GameStatus(true);
            }
            else if (this.game.Hangman.IsGameOver())
            {
                this.game.GameInfo.GameStatus(false);
            }
            else
            {
                (sender as Button).IsEnabled = false;
            }
        }
    }
}
