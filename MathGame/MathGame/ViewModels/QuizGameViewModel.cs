namespace MathGame.ViewModels
{
    using MathGame.Common;
    using System;

    public class QuizGameViewModel : GameViewModel
    {
        
        public QuizViewModel Quiz { get; set; }
        public GameInfoViewModel GameInfo { get; set; }
        public TimerViewModel Timer { get; set; }

        public QuizGameViewModel()
        {
            this.SetupGame();
        }

        private void SetupGame()
        {
            this.Quiz = new QuizViewModel();
            this.Timer = new TimerViewModel(new TimeSpan(0, 0, Constants.playSeconds));
            this.GameInfo = new GameInfoViewModel();

            this.GameInfo.ClearInfo();
            //this.GameInfo.MatchAttempts = this.Quiz.Quiz.Count*2;
            this.GameInfo.MatchAttempts = 100;

            Timer.Start();

            //Updates
            OnPropertyChanged("Quiz");
            OnPropertyChanged("Timer");
            OnPropertyChanged("GameInfo");
        }

        public void Restart()
        {
            SoundManager.PlayIncorrect();
            SetupGame();
        }

        //Status of the current game
        private void GameStatus()
        {
            //if (GameInfo.QuestionsCount < 0)
            //{
                this.GameInfo.GameStatus(false);
                this.Timer.Stop();
            //}

            //if (Slides.AllSlidesMatched)
            //{
            //    this.GameInfo.GameStatus(true);
            //    this.Timer.Stop();
            //}
        }

        //Slide has been clicked
        public void ClickedAnswer(object data)
        {
            var selected = data as QuizViewModel;
            //selected.
            //this.Quiz.SelectSlide(selected);

            //if (!this.Slides.AreSlidesActive)
            //{
            //    if (this.Slides.CheckIfMatched())
            //        this.GameInfo.Award(); //Correct match
            //    else
            //        this.GameInfo.Penalize();//Incorrect match
            //}

            this.GameStatus();
        }
    }
}
