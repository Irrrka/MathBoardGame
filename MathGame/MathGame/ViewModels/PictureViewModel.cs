using MathGame.Data;
using System.Windows.Media;

namespace MathGame.ViewModels
{
    public class PictureViewModel:ObservableObject
    {
        //Model for this view
        private Image image;

        //Id of this slide
        public int Id { get; private set; }

        //Slide status
        private bool isViewed;
        private bool isMatched;
        private bool isFailed;

        //Is being viewed by user
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

        //Has been matched
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

        //Has failed to be matched
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

        //User can select this slide
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

        //Image to be displayed
        public string SlideImage
        {
            get
            {
                if (this.IsMatched)
                    return image.Path;
                if (this.IsViewed)
                    return image.Path;


                return "/MemoryGame;component/Resources/background_image.jpg";
            }
        }

        //Brush color of border based on status
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


        public PictureViewModel(Image model)
        {
            this.image = model;
            this.Id = model.Id;
        }

        //Has been matched
        public void MarkMatched()
        {
            this.IsMatched = true;
        }

        //Has failed to match
        public void MarkFailed()
        {
            this.IsFailed = true;
        }

        //No longer being viewed
        public void ClosePeek()
        {
            this.IsViewed = false;
            this.IsFailed = false;
            OnPropertyChanged("IsSelectable");
            OnPropertyChanged("SlideImage");
        }

        //Let user view
        public void PeekAtImage()
        {
            this.IsViewed = true;
            OnPropertyChanged("SlideImage");
        }
    }
}