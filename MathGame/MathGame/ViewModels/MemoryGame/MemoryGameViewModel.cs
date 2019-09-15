namespace MathGame.ViewModels
{
    using MathGame.Common;
    using System;

    public class MemoryGameViewModel : GameViewModel
    {
        public MemoryGameViewModel()
        {
            this.SetupGame();
        }

        public ImageCollectionViewModel Slides { get; set; }
        public GameInfoViewModel GameInfo { get; set; }
        public TimerViewModel Timer { get; set; }

        private void SetupGame()
        {
          this.Slides = new ImageCollectionViewModel();
          this.Timer = new TimerViewModel(new TimeSpan(0, 0, Constants.playSeconds));
          this.GameInfo = new GameInfoViewModel();

          this.GameInfo.ClearInfo();

           //Create slides from image folder then display to be memorized
           this.Slides.CreateSlides("Resources/Images");
           this.Slides.Memorize();

            //Game has started, begin count.
            this.Timer.Start();

            //Slides have been updated
            OnPropertyChanged("Slides");
            OnPropertyChanged("Timer");
            OnPropertyChanged("GameInfo");
        }

        //Slide has been clicked
        public void ClickedSlide(object slide)
        {
            if (this.Slides.CanSelect)
            {
                var selected = slide as ImageViewModel;
                this.Slides.SelectSlide(selected);
            }

            if (!this.Slides.AreSlidesActive)
            {
                if (this.Slides.CheckIfMatched())
                    this.GameInfo.Award(); //Correct match
                else
                    this.GameInfo.Penalize();//Incorrect match
            }

            this.GameStatus();
        }

        //Status of the current game
        private void GameStatus()
        {
            if (GameInfo.MatchAttempts < 0)
            {
                this.GameInfo.GameStatus(false);
                this.Slides.RevealUnmatched();
                this.Timer.Stop();
            }

            if (Slides.AllSlidesMatched)
            {
                this.GameInfo.GameStatus(true);
                this.Timer.Stop();
            }
        }

        //Restart game
        public void Restart()
        {
            SoundManager.PlayIncorrect();
            SetupGame();
        }

    }
}
