namespace MathGame.ViewModels
{
    using MathGame.Common;
    using System;
    using System.Windows.Threading;

    public class TimerViewModel:ObservableObject
    {
        private DispatcherTimer playedTimer;
        private TimeSpan timePlayed;

        public TimeSpan Time
        {
            get
            {
                return this.timePlayed;
            }
            set
            {
                this.timePlayed = value;
                OnPropertyChanged();
            }
        }

        public TimerViewModel(TimeSpan time)
        {
            this.playedTimer = new DispatcherTimer();
            this.playedTimer.Interval = time;
            this.playedTimer.Tick += PlayedTimer_Tick;
            this.timePlayed = new TimeSpan();
        }

        public void Start()
        {
            this.playedTimer.Start();
        }

        public void Stop()
        {
            this.playedTimer.Stop();
        }

        private void PlayedTimer_Tick(object sender, EventArgs e)
        {
            Time = this.timePlayed.Add(new TimeSpan(0, 0, Constants.playSeconds));
        }
    }
}