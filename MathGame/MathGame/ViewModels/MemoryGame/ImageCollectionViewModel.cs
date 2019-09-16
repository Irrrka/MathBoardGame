namespace MathGame.ViewModels
{
    using MathGame.Common;
    using MathGame.Data;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Windows.Threading;

    public class ImageCollectionViewModel:NotifyPropertyChanged
    {
        private ImageViewModel SelectedSlide1;
        private ImageViewModel SelectedSlide2;

        private DispatcherTimer peekTimer;
        private DispatcherTimer openingTimer;

        public ImageCollectionViewModel()
        {
            this.peekTimer = new DispatcherTimer();
            this.peekTimer.Interval = new TimeSpan(0, 0, Constants.peekSeconds);
            this.peekTimer.Tick += PeekTimer_Tick;

            this.openingTimer = new DispatcherTimer();
            this.openingTimer.Interval = new TimeSpan(0, 0, Constants.openSeconds);
            this.openingTimer.Tick += OpeningTimer_Tick;
        }

        public ObservableCollection<ImageViewModel> MemorySlides { get; private set; }

        public bool AreSlidesActive
        {
            get
            {
                if (this.SelectedSlide1 == null || this.SelectedSlide2 == null)
                    return true;

                return false;
            }
        }

        public bool AllSlidesMatched
        {
            get
            {
                foreach (var slide in MemorySlides)
                {
                    if (!slide.IsMatched)
                        return false;
                }

                return true;
            }
        }

        public void CreateSlides(string imagesPath)
        {
            MemorySlides = new ObservableCollection<ImageViewModel>();
            List<Image> models = GetModelsFrom(@imagesPath);

            for (int i = 0; i < Constants.slidesToMatch; i++)
            {
                var newSlide = new ImageViewModel(models[i]);
                var newSlideMatch = new ImageViewModel(models[i]);
                MemorySlides.Add(newSlide);
                MemorySlides.Add(newSlideMatch);
                newSlide.PeekAtImage();
                newSlideMatch.PeekAtImage();
            }

            this.ShuffleSlides();
            OnPropertyChanged("MemorySlides");
        }

        public bool CanSelect { get; private set; }

        public void SelectSlide(ImageViewModel slide)
        {
            slide.PeekAtImage();

            if (SelectedSlide1 == null)
            {
                SelectedSlide1 = slide;
            }
            else if (SelectedSlide2 == null)
            {
                SelectedSlide2 = slide;
                HideUnmatched();
            }

            SoundManager.PlayCardFlip();
            OnPropertyChanged("AreSlidesActive");
        }

        public bool CheckIfMatched()
        {
            if (SelectedSlide1.Id == SelectedSlide2.Id)
            {
                MatchCorrect();
                return true;
            }
            else
            {
                MatchFailed();
                return false;
            }
        }

        private void MatchFailed()
        {
            SelectedSlide1.MarkFailed();
            SelectedSlide2.MarkFailed();
            ClearSelected();
        }

        private void MatchCorrect()
        {
            SelectedSlide1.MarkMatched();
            SelectedSlide2.MarkMatched();
            ClearSelected();
        }

        private void ClearSelected()
        {
            SelectedSlide1 = null;
            SelectedSlide2 = null;
            CanSelect = false;
        }

        public void RevealUnmatched()
        {
            foreach (var slide in MemorySlides)
            {
                if (!slide.IsMatched)
                {
                    this.peekTimer.Stop();
                    slide.MarkFailed();
                    slide.PeekAtImage();
                }
            }
        }

        public void HideUnmatched()
        {
            this.peekTimer.Start();
        }

        public void Memorize()
        {
            this.openingTimer.Start();
        }

        private List<Image> GetModelsFrom(string relativePath)
        {
            var models = new List<Image>();
            string[] images = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, @"Resources\Images"));
            var id = 0;

            foreach (string i in images)
            {
                models.Add(new Image() { Id = id, Path = i});
                id++;
            }

            return models;
        }

        private void ShuffleSlides()
        {
            var rnd = new Random();
            for (int i = 0; i < (MemorySlides.Count * MemorySlides.Count); i++)
            {
                MemorySlides.Reverse();
                MemorySlides.Move(rnd.Next(0, MemorySlides.Count), rnd.Next(0, MemorySlides.Count));
            }
        }

        private void OpeningTimer_Tick(object sender, EventArgs e)
        {
            foreach (var slide in MemorySlides)
            {
                slide.ClosePeek();
                CanSelect = true;
            }
            OnPropertyChanged("AreSlidesActive");
            this.openingTimer.Stop();
        }

        private void PeekTimer_Tick(object sender, EventArgs e)
        {
            foreach (var slide in MemorySlides)
            {
                if (!slide.IsMatched)
                {
                    slide.ClosePeek();
                    CanSelect = true;
                }
            }
            OnPropertyChanged("AreSlidesActive");
            this.peekTimer.Stop();
        }
    }
}
