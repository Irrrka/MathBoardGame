namespace MathGame.ViewModels
{
    using MathGame.Data;
    using System.Windows.Media;

    public class ImageViewModel:NotifyPropertyChanged
    {
        private Image image;

        public int Id { get; private set; }

        private bool isViewed;
        private bool isMatched;
        private bool isFailed;

        public ImageViewModel(Image model)
        {
            this.image = model;
            this.Id = model.Id;
        }

        public string SlideImage
        {
            get
            {
                if (this.IsMatched)
                    return this.image.Path;
                if (this.IsViewed)
                    return this.image.Path;


                return "/MathGame;component/Resources/back_image.jpg";
            }
        }

        public Brush BorderBrush
        {
            get
            {
                if (this.IsFailed)
                    return Brushes.Red;
                if (this.IsMatched)
                    return Brushes.Green;
                if (this.IsViewed)
                    return Brushes.Yellow;

                return Brushes.Black;
            }
        }

        public bool IsViewed
        {
            get
            {
                return this.isViewed;
            }
            private set
            {
                this.isViewed = value;
                OnPropertyChanged("SlideImage");
                OnPropertyChanged("BorderBrush");
            }
        }

        public bool IsMatched
        {
            get
            {
                return this.isMatched;
            }
            private set
            {
                this.isMatched = value;
                OnPropertyChanged("SlideImage");
                OnPropertyChanged("BorderBrush");
            }
        }

        public bool IsFailed
        {
            get
            {
                return this.isFailed;
            }
            private set
            {
                this.isFailed = value;
                OnPropertyChanged("SlideImage");
                OnPropertyChanged("BorderBrush");
            }
        }

        public bool IsSelectable
        {
            get
            {
                if (this.IsMatched)
                    return false;
                if (this.IsViewed)
                    return false;

                return true;
            }
        }

        public void MarkMatched()
        {
            this.IsMatched = true;
        }

        public void MarkFailed()
        {
            this.IsFailed = true;
        }

        public void ClosePeek()
        {
            this.IsViewed = false;
            this.IsFailed = false;
            OnPropertyChanged("IsSelectable");
            OnPropertyChanged("SlideImage");
        }

        public void PeekAtImage()
        {
            this.IsViewed = true;
            OnPropertyChanged("SlideImage");
        }
    }
}