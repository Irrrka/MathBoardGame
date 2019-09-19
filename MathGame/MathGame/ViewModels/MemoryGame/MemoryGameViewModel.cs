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

           //TODO COMMAND+Service
           this.Slides.CreateSlides("Resources/Images");
           this.Slides.Memorize();

           this.Timer.Start();

            OnPropertyChanged("Slides");
            OnPropertyChanged("Timer");
            OnPropertyChanged("GameInfo");
        }

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

        private void GameStatus()
        {
            if (this.GameInfo.MatchAttempts < 0)
            {
                this.GameInfo.GameStatus(false);
                this.Slides.RevealUnmatched();
                //this.Timer.Stop();
            }

            if (this.Slides.AllSlidesMatched)
            {
                this.GameInfo.GameStatus(true);
                //this.Timer.Stop();
            }
        }

        public void Restart()
        {
            this.SetupGame();
        }

    }
}
