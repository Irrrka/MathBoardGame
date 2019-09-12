﻿namespace MathGame.ViewModels
{
    using MathGame.Common;
    using MathGame.Data;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Threading;

    public class SlideCollectionViewModel:ObservableObject
    {
        public ObservableCollection<PictureViewModel> MemorySlides { get; private set; }

        private PictureViewModel SelectedSlide1;
        private PictureViewModel SelectedSlide2;

        //Timers for peeking at slides and initial display for memorizing
        private DispatcherTimer peekTimer;
        private DispatcherTimer openingTimer;

        //Are selected slides still being displayed
        public bool AreSlidesActive
        {
            get
            {
                if (this.SelectedSlide1 == null || this.SelectedSlide2 == null)
                    return true;

                return false;
            }
        }

        //Have all slides been matched
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

        //Can user select a slide
        public bool CanSelect { get; private set; }


        public SlideCollectionViewModel()
        {
            this.peekTimer = new DispatcherTimer();
            this.peekTimer.Interval = new TimeSpan(0, 0, Constants.peekSeconds);
            this.peekTimer.Tick += PeekTimer_Tick;

            this.openingTimer = new DispatcherTimer();
            this.openingTimer.Interval = new TimeSpan(0, 0, Constants.openSeconds);
            this.openingTimer.Tick += OpeningTimer_Tick;
        }

        //Create slides from images in file directory
        public void CreateSlides(string imagesPath)
        {
            //New list of slides
            MemorySlides = new ObservableCollection<PictureViewModel>();
            var models = GetModelsFrom(@imagesPath);

            //Create slides with matching pairs from models
            for (int i = 0; i < 6; i++)
            {
                //Create 2 matching slides
                var newSlide = new PictureViewModel(models[i]);
                var newSlideMatch = new PictureViewModel(models[i]);
                //Add new slides to collection
                MemorySlides.Add(newSlide);
                MemorySlides.Add(newSlideMatch);
                //Initially display images for user
                newSlide.PeekAtImage();
                newSlideMatch.PeekAtImage();
            }

            ShuffleSlides();
            OnPropertyChanged("MemorySlides");
        }

        //Select a slide to be matched
        public void SelectSlide(PictureViewModel slide)
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

        //Are the selected slides a match
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

        //Selected slides did not match
        private void MatchFailed()
        {
            SelectedSlide1.MarkFailed();
            SelectedSlide2.MarkFailed();
            ClearSelected();
        }

        //Selected slides matched
        private void MatchCorrect()
        {
            SelectedSlide1.MarkMatched();
            SelectedSlide2.MarkMatched();
            ClearSelected();
        }

        //Clear selected slides
        private void ClearSelected()
        {
            SelectedSlide1 = null;
            SelectedSlide2 = null;
            CanSelect = false;
        }

        //Reveal all unmatched slides
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

        //Hid all slides that are unmatched
        public void HideUnmatched()
        {
            this.peekTimer.Start();
        }

        //Display slides for memorizing
        public void Memorize()
        {
            this.openingTimer.Start();
        }

        //Get slide picture models for creating picture views
        private List<Image> GetModelsFrom(string relativePath)
        {
            //List of models for picture slides
            var models = new List<Image>();
            //Get all image URIs in folder
            string[] images = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, @"Resources\Images"));
            //Slide id begin at 0
            var id = 0;

            foreach (string i in images)
            {
                models.Add(new Image() { Id = id, Path = "/MathGame;component/" + i });
                id++;
            }

            return models;
        }

        //Randomize the location of the slides in collection
        private void ShuffleSlides()
        {
            //Randomizing slide indexes
            var rnd = new Random();
            //Shuffle memory slides
            for (int i = 0; i < 36; i++)
            {
                MemorySlides.Reverse();
                MemorySlides.Move(rnd.Next(0, MemorySlides.Count), rnd.Next(0, MemorySlides.Count));
            }
        }

        //Close slides being memorized
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

        //Display selected card
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
