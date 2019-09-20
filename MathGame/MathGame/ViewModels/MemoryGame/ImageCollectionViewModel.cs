namespace MathGame.ViewModels
{
    using MathGame.Common;
    using MathGame.Data;
    using MathGame.Services.Contracts;
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
        //private readonly IMemoryService memoryService;

        public ImageCollectionViewModel(
            //IMemoryService memoryService
            )
        {
            //this.memoryService = memoryService;

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
                foreach (var slide in this.MemorySlides)
                {
                    if (!slide.IsMatched)
                        return false;
                }

                return true;
            }
        }

        public void CreateSlides(string imagesPath)
        {
            this.MemorySlides = new ObservableCollection<ImageViewModel>();
            List<Image> models = this.GetModelsFrom(imagesPath);

            for (int i = 0; i < Constants.slidesToMatch; i++)
            {
                var newSlide = new ImageViewModel(models[i]);
                var newSlideMatch = new ImageViewModel(models[i]);
                this.MemorySlides.Add(newSlide);
                this.MemorySlides.Add(newSlideMatch);
                newSlide.PeekAtImage();
                newSlideMatch.PeekAtImage();
            }

            this.ShuffleSlides();
            OnPropertyChanged("MemorySlides");
        }

        public List<Image> GetModelsFrom(string relativePath)
        {
            var models = new List<Image>();
            string[] images = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, @"Resources\Images"));
            var id = 0;

            foreach (string i in images)
            {
                models.Add(new Image() { Id = id, Path = i });
                id++;
            }

            return models;
        }

        public bool CanSelect { get; private set; }

        public void SelectSlide(ImageViewModel slide)
        {
            slide.PeekAtImage();

            if (this.SelectedSlide1 == null)
            {
                this.SelectedSlide1 = slide;
            }
            else if (this.SelectedSlide2 == null)
            {
                this.SelectedSlide2 = slide;
                this.HideUnmatched();
            }

            SoundManager.PlayCardFlip();
            OnPropertyChanged("AreSlidesActive");
        }

        public bool CheckIfMatched()
        {
            if (this.SelectedSlide1.Id == this.SelectedSlide2.Id)
            {
                this.MatchCorrect();
                return true;
            }
            else
            {
                this.MatchFailed();
                return false;
            }
        }

        private void MatchFailed()
        {
            this.SelectedSlide1.MarkFailed();
            this.SelectedSlide2.MarkFailed();
            this.ClearSelected();
        }

        private void MatchCorrect()
        {
            this.SelectedSlide1.MarkMatched();
            this.SelectedSlide2.MarkMatched();
            this.ClearSelected();
        }

        private void ClearSelected()
        {
            this.SelectedSlide1 = null;
            this.SelectedSlide2 = null;
            this.CanSelect = false;
        }

        public void RevealUnmatched()
        {
            foreach (var slide in this.MemorySlides)
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

        private void ShuffleSlides()
        {
            var rnd = new Random();
            for (int i = 0; i < (this.MemorySlides.Count * this.MemorySlides.Count); i++)
            {
                this.MemorySlides.Reverse();
                this.MemorySlides.Move(rnd.Next(0, this.MemorySlides.Count), rnd.Next(0, this.MemorySlides.Count));
            }
        }

        private void OpeningTimer_Tick(object sender, EventArgs e)
        {
            foreach (var slide in MemorySlides)
            {
                slide.ClosePeek();
                this.CanSelect = true;
            }
            this.openingTimer.Stop();
            OnPropertyChanged("AreSlidesActive");
        }

        private void PeekTimer_Tick(object sender, EventArgs e)
        {
            foreach (var slide in this.MemorySlides)
            {
                if (!slide.IsMatched)
                {
                    slide.ClosePeek();
                    this.CanSelect = true;
                }
            }
            this.peekTimer.Stop();
            OnPropertyChanged("AreSlidesActive");
        }
    }
}
