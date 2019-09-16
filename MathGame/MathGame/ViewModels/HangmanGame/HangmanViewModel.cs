namespace MathGame.ViewModels.HangmanGame
{
    using MathGame.Data;
    using MathGame.Services.Contracts;
    using System;
    using System.IO;
    using System.Linq;

    public class HangmanViewModel:NotifyPropertyChanged
    {
        //private IHangmanService hangmanService;
        private string word;
        private int stage;
        private Image stageImage;

        public HangmanViewModel(
            //IHangmanService hangmanService
            )
        {
            //this.hangmanService = hangmanService;
            this.stage = 0;
            this.stageImage = new Image();
        }

        public string Word
        {
            get
            {
                return this.word;
            }
        }

        public int Lenght
        {
            get
            {
                return this.word.Length;
            }
        }

        public Image StageImage
        {
            get
            {
                return this.stageImage;
            }
            set
            {
                this.stageImage = value;
                OnPropertyChanged();
            }
        }

        public int Stage
        {
            get
            {
                return this.stage;
            }
            set
            {
                this.stage = value;
                OnPropertyChanged();
            }
        }

        public int[] TakeCharachter(char letter)
        {
            int[] temp = new int[this.word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                if (this.word.ToUpper()[i] == letter)
                {
                    temp[i] = 1;
                }
                else
                {
                    temp[i] = 0;
                    this.stage++;
                }

                //if (temp.Count(i => i == 1) == 0)
                //{
                //    Stage++;
                //}
            }

            return temp;
        }

        public Image GetStageImage()
        {
            string[] images = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, @"Resources\Hangman"));

            var image = this.StageImage = new Image() { Path = $"{this.Stage}.png" };

            return image;
        }

        public bool IsGameOver()
        {
            return this.stage >= 7 ? true : false;
        }
    }
}
