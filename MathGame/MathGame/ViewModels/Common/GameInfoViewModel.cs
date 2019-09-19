using MathGame.Common;
using System.Windows;

namespace MathGame.ViewModels
{
    public class GameInfoViewModel : NotifyPropertyChanged
    {
        private int matchAttempts;
        private int scores;
        private bool isGameWin;
        private bool isGameLost;

        public GameInfoViewModel()
        {
            this.MatchAttempts = this.matchAttempts;
            this.Scores = this.scores;
        }
        public int MatchAttempts
        {
            get
            {
                return this.matchAttempts;
            }
            internal set
            {
                this.matchAttempts = value;
                OnPropertyChanged();
            }
        }

        public int Scores
        {
            get
            {
                return this.scores;
            }
            private set
            {
                this.scores = value;
                OnPropertyChanged();
            }
        }

        public Visibility LostMessage
        {
            get
            {
                if (this.isGameLost)
                    return Visibility.Visible;

                return Visibility.Hidden;
            }
        }

        public Visibility WinMessage
        {
            get
            {
                if (this.isGameWin)
                    return Visibility.Visible;

                return Visibility.Hidden;
            }
        }

        public void GameStatus(bool win)
        {
            if (!win)
            {
                this.isGameLost = true;
                OnPropertyChanged("LostMessage");
            }

            if (win)
            {
                this.isGameWin = true;
                OnPropertyChanged("WinMessage");
            }
        }

        public void ClearInfo()
        {
            this.Scores = 0;
            this.MatchAttempts = Constants.memoAttempts;
            this.isGameLost = false;
            this.isGameWin = false;
            OnPropertyChanged("LostMessage");
            OnPropertyChanged("WinMessage");
        }

        public void Award()
        {
            this.Scores += Constants.pointAward;
            SoundManager.PlayCorrect();
        }

        public void Penalize()
        {
            //Refactor MatchAttempts remove to memorygameVM
            this.Scores -= Constants.pointLoss;
            this.MatchAttempts--;
            SoundManager.PlayIncorrect();
        }
    }
}