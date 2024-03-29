﻿namespace MathGame.ViewModels.HangmanGame
{
    using MathGame.Common;
    using MathGame.Data;
    using MathGame.Services.Contracts;
    using System;
    using System.IO;
    using System.Linq;
    using System.Windows.Input;

    public class HangmanGameViewModel : GameViewModel
    {
        private readonly IHangmanService hangmanService;
        private ICommand generateWordCommand;
        private ICommand generateLettersCommand;
        private string word;
        private char[] alphabet;
        private int stage;

        private Image stageImage;
 
        public HangmanGameViewModel(IHangmanService hangmanService)
        {
            this.hangmanService = hangmanService;
            this.SetupGame();
        }

        public HangmanGameViewModel()
        {
        }

        public GameInfoViewModel GameInfo { get; set; }

        public TimerViewModel Timer { get; set; }

        private void SetupGame()
        {
            this.Timer = new TimerViewModel(new TimeSpan(0, 0, Constants.playSeconds));
            this.GameInfo = new GameInfoViewModel();

            this.StageImage = this.GetStageImage();
            this.Timer.Start();
            this.GenerateWord(null);
            this.GenerateLetters(null);

            OnPropertyChanged("Timer");
            OnPropertyChanged("GameInfo");
            OnPropertyChanged("StageImage");
        }

        public ICommand GenerateWordCommand
        {
            get
            {
                //if (this.generateWordCommand == null)
                //{
                    this.generateWordCommand = new RelayCommand<object>(GenerateWord);
                //}
                return this.generateWordCommand;
            }
        }

        public ICommand GenerateLettesrCommand
        {
            get
            {
                //if (this.generateLettersCommand == null)
                //{
                    this.generateLettersCommand = new RelayCommand<object>(GenerateLetters);
                //}
                return this.generateLettersCommand;
            }
        }

        private void GenerateLetters(object data)
        {
            this.alphabet = this.hangmanService.ShowLetters();
        }

        private void GenerateWord(object data)
        {
            this.word = this.hangmanService.GetWord();
        }

        public string Word
        {
            get
            {
                return this.word;
            }
        }

        public char[] Alphabet
        {
            get
            {
                return this.alphabet;
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

        public Image GetStageImage()
        {
            string[] images = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, @"Resources\Hangman"));

            var image = this.StageImage = new Image() { Path = "/MathGame;component/Resources/Hangman/" + $"{this.Stage}.png" };

            return image;
        }

        public bool IsGameOver()
        {
            return this.stage >= 7 ? true : false;
        }

        public int[] TakeCharachter(char letter)
        {
            int[] temp = new int[this.word.Length];
            for (int i = 0; i < this.word.Length; i++)
            {
                var targetLetter = this.word[i];
                if (targetLetter == letter)
                {
                    temp[i] = 1;
                    this.GameInfo.Award();
                }
                else
                {
                    temp[i] = 0;
                }
            }
            if (temp.Count(i => i == 1) == 0)
            {
                this.Stage++;
                this.GameInfo.Penalize();
            }

            this.GameStatus();

            return temp;
        }

        private void GameStatus()
        {
            if (this.Stage >= 7)
            {
                this.GameInfo.GameStatus(false);
                this.StageImage = new Image();
                this.Timer.Stop();
            }
        }

    }
}
