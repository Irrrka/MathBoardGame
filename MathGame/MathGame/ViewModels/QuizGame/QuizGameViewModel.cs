namespace MathGame.ViewModels
{
    using MathGame.Common;
    using MathGame.Data;
    using MathGame.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Input;

    public class QuizGameViewModel : GameViewModel
    {
        private readonly IQuizService quizService;
        private ICommand createQuizCommand;
        private List<QuizQuestion> quiz;
        private int questionId;

        public ObservableCollection<QuestionViewModel> Quiz { get; set; }
        public GameInfoViewModel GameInfo { get; set; }
        public TimerViewModel Timer { get; set; }

        public QuizGameViewModel(IQuizService quizService)
        {
            this.quizService = quizService;
            this.SetupGame();
            this.CreateQuiz();
        }
        public QuizGameViewModel()
        {
        }

        public int QuestionId
        {
            get
            {
                return this.questionId;
            }
            set
            {
                this.questionId = value;
                OnPropertyChanged();
            }
        }
        public string CurrentQuestion
        {
            get
            {
                return this.quiz[this.QuestionId].Question;
            }
        }
        public string CurrentOption1
        {
            get
            {
                return this.quiz[this.QuestionId].Answer1;
            }
        }
        public string CurrentOption2
        {
            get
            {
                return this.quiz[this.QuestionId].Answer2;
            }
        }
        public string CorrectAnswer
        {
            get
            {
                return this.quiz[this.QuestionId].CorrectAnswer;
            }
        }

        public ICommand CreateQuizCommand
        {
            get
            {
                if (this.createQuizCommand == null)
                {
                    this.createQuizCommand = new RelayCommand<object>(CreateQuiz);
                }
                return this.createQuizCommand;
            }
        }

        public void CreateQuiz(object data = null)
        {
            this.quiz = this.QuizQuestions();
            var temp = this.quizService.CreateQuiz(this.quiz);

            foreach (QuestionViewModel question in temp)
            {
                this.Quiz.Add(question);
            }

            //this.ShuffleQuestions();
            OnPropertyChanged("Quiz");
        }

        private List<QuizQuestion> QuizQuestions()
        {
            this.quiz = this.quizService.GenerateQuizQuestions();
            return this.quiz;
        }

        private void ShuffleQuestions()
        {
            var rnd = new Random();

            for (int i = 0; i < (this.Quiz.Count * this.Quiz.Count); i++)
            {
                this.Quiz.Reverse();
                this.Quiz.Move(rnd.Next(0, this.Quiz.Count), rnd.Next(0, this.Quiz.Count));
            }
        }

        private void SetupGame()
        {
            this.Quiz = new ObservableCollection<QuestionViewModel>();
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
            this.SetupGame();
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
            var selected = data as QuestionCollectionViewModel;
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

        public void StoreAnswer(string selectedOption)
        {
            if (selectedOption == "OK")
            {
                this.QuestionId--;
            }
            else if (selectedOption != "OK")
            {
                QuizData.qaData[(this.QuestionId - 1), 4] = selectedOption;
            }
        }

    }
}
