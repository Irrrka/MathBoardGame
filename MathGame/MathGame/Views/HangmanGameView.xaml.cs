namespace MathGame.Views
{
    using Autofac;
    using MathGame.ViewModels;
    using MathGame.ViewModels.HangmanGame;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

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
            this.game = this.DataContext as HangmanGameViewModel;
            this.labels = new List<Label>();
            this.buttons = new List<Button>();
            this.GenerateLettersButtons(this.game.Alphabet);
            this.GenerateLettersLabels(this.game.Lenght);
        }
        
        private void PlayAgain(object sender, RoutedEventArgs e)
        {
            
            this.labels.Clear();
            this.buttons.Clear();
            GameGrid.Children.Clear();

            var game = new HangmanGameViewModel();
            game.Restart();
            this.GenerateLettersButtons(this.game.Alphabet);
            this.GenerateLettersLabels(this.game.Lenght);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ShowAnswer_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
        }

        private void GenerateLettersLabels(int lenght)
        {
            for (int i = 0; i < lenght; i++)
            {
                Label label = new Label();
                label.FontSize = 20;
                label.FontWeight = FontWeight;
                label.HorizontalContentAlignment = HorizontalAlignment.Center;
                label.VerticalContentAlignment = VerticalAlignment.Center;
                label.BorderThickness = new Thickness(1, 1, 1, 1);
                label.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x2D, 0x2D, 0x30));
                label.Height = label.Width = 38;
                label.HorizontalAlignment = HorizontalAlignment.Left;
                label.VerticalAlignment = VerticalAlignment.Top;

                label.Name = "Character" + i.ToString();

                label.Margin = new Thickness(i * label.Width, 0d, 0d, 0d);

                this.labels.Add(label);

                GameGrid.Children.Add(label);
            }
        }

        private void Letter_Click(object sender, RoutedEventArgs e)
        {
            int[] temp = this.game.TakeCharachter((sender as Button).Content.ToString()[0]);

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == 1)
                {
                    this.labels[i].Content = this.game.Word[i];
                }
            }

            this.game.StageImage.Path = this.game.GetStageImage().Path;

            if (this.labels.Count(l => l.Content == null) == 0)
            {
                this.game.GameInfo.GameStatus(true);
            }
            else if (this.game.IsGameOver())
            {
                this.game.GameInfo.GameStatus(false);
            }
            else
            {
                (sender as Button).IsEnabled = false;
            }
        }

        private void GenerateLettersButtons(char[] alphabet)
        {
            double bot = 0;
            int count = 0;
            for (int i = 0; i < alphabet.Length; i++, count++)
            {
                Button button = new Button();
                button.FontSize = 20;
                button.FontWeight = FontWeight;
                button.HorizontalContentAlignment = HorizontalAlignment.Center;
                button.VerticalContentAlignment = VerticalAlignment.Center;
                button.Height = button.Width = 38;
                button.HorizontalAlignment = HorizontalAlignment.Left;
                button.VerticalAlignment = VerticalAlignment.Bottom;

                button.Content = alphabet[i].ToString();

                if ((count + 1) * button.Width > GameGrid.Width)
                {
                    count = 0;
                    bot += button.Height;
                }

                button.Margin = new Thickness(count * button.Width, 0, 0, bot);
                button.Click += new RoutedEventHandler(Letter_Click);

                this.buttons.Add(button);

                GameGrid.Children.Add(button);
            }
        }
    }
}
