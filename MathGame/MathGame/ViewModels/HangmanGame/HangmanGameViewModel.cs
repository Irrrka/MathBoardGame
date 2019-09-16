using MathGame.Common;
using MathGame.Data;
using MathGame.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MathGame.ViewModels.HangmanGame
{
    public class HangmanGameViewModel : GameViewModel
    {
        private readonly IHangmanService hangmanService;
        private ICommand generateWordCommand;
        private ICommand generateLettersCommand;
        private string word;
        private Image stageImage;
 
        public HangmanGameViewModel(IHangmanService hangmanService)
        {
            this.hangmanService = hangmanService;
            this.SetupGame();
        }

        private void SetupGame()
        {
            this.Hangman = new HangmanViewModel();
            this.Timer = new TimerViewModel(new TimeSpan(0, 0, Constants.playSeconds));
            this.GameInfo = new GameInfoViewModel();

            this.Hangman.StageImage = this.Hangman.GetStageImage();
            this.Timer.Start();

            this.generateWordCommand = this.GenerateWordCommand;
            this.generateLettersCommand = this.GenerateLettesrCommand;

            this.Hangman = new HangmanViewModel();

            OnPropertyChanged("Timer");
            OnPropertyChanged("GameInfo");
        }

        public HangmanViewModel Hangman { get; private set; }
        public GameInfoViewModel GameInfo { get; set; }
        public TimerViewModel Timer { get; set; }

        public ICommand GenerateWordCommand
        {
            get
            {
                if (this.generateWordCommand == null)
                {
                    this.generateWordCommand = new RelayCommand<object>(GenerateWord);
                }
                return this.generateWordCommand;
            }
        }

        public ICommand GenerateLettesrCommand
        {
            get
            {
                if (this.generateLettersCommand == null)
                {
                    this.generateLettersCommand = new RelayCommand<object>(GenerateLetters);
                }
                return this.generateLettersCommand;
            }
        }

        private void GenerateLetters(object data)
        {
            this.hangmanService.ShowLetters();
        }

        private void GenerateWord(object data)
        {
            this.word = this.hangmanService.GetWord();
        }

        //public void ClickedLetter(object letter)
        //{
        //    if (this.Slides.CanSelect)
        //    {
        //        var selected = slide as ImageViewModel;
        //        this.Slides.SelectSlide(selected);
        //    }

        //    if (!this.Slides.AreSlidesActive)
        //    {
        //        if (this.Slides.CheckIfMatched())
        //            this.GameInfo.Award(); //Correct match
        //        else
        //            this.GameInfo.Penalize();//Incorrect match
        //    }

        //    this.GameStatus();
        //}

        private void GameStatus()
        {
            // matchattempts >> Stage>=7
            if (GameInfo.MatchAttempts < 0)
            {
                this.GameInfo.GameStatus(false);
                this.Hangman.StageImage = new Image();
                this.Timer.Stop();
            }

        }

        public void Restart()
        {
            SoundManager.PlayIncorrect();
            SetupGame();
        }
    }
}
