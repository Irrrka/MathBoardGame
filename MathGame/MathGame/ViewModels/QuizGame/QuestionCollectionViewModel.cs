using MathGame.Data;
using MathGame.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MathGame.ViewModels
{
    public class QuestionCollectionViewModel : NotifyPropertyChanged
    {
        private readonly IQuizService quizService;
        private List<QuizQuestion> quiz;
        private ICommand quizQuestionsCommand;
        private ICommand createQuizCommand;


        //Question status
        private bool isAnswered;
        private bool isCorrect;
        private bool isFailed;

        public QuestionCollectionViewModel(IQuizService quizService)
        {
            this.Quiz = new ObservableCollection<QuestionViewModel>();
            this.quizService = quizService;
        }

        public QuestionCollectionViewModel()
        {
        }

        public ObservableCollection<QuestionViewModel> Quiz { get; set; }

        public QuestionViewModel SelectedAnswer;
        public QuestionViewModel CorrectAnswer;



        //public ICommand QuizQuestionsCommand
        //{
        //    get
        //    {
        //        if (this.quizQuestionsCommand == null)
        //        {
        //            this.quizQuestionsCommand = new RelayCommand<object>(QuizQuestions);
        //        }
        //        return this.quizQuestionsCommand;
        //    }
        //}

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

        private List<QuizQuestion> QuizQuestions()
        {
            this.quiz = this.quizService.GenerateQuizQuestions();
            return this.quiz;
        }

        public void CreateQuiz(object data = null)
        {
            this.quiz = this.QuizQuestions();
            var temp = this.quizService.CreateQuiz(this.quiz);

            foreach (var question in temp)
            {
                this.Quiz.Add(question);
            }

            this.ShuffleQuestions();
            OnPropertyChanged("Quiz");
        }

        public bool IsQuestionAnswered
        {
            get
            {
                if (this.SelectedAnswer == null)
                    return true;

                return false;
            }
        }


        //TODO ???
        //public bool AllQuestionsAnswered
        //{
        //    get
        //    {
        //        foreach (var q in this.Quiz)
        //        {
        //            if (!q.IsCorrect)
        //                return false;
        //        }

        //        return true;
        //    }
        //}


        public bool CheckIfCorrect()
        {
            if (this.SelectedAnswer == this.CorrectAnswer)
            {
                this.AnswerCorrect();
                return true;
            }
            else
            {
                this.AnswerFail();
                return false;
            }
        }

        //Selected answer did not match
        private void AnswerFail()
        {
            SelectedAnswer.AnswerFail();
        }

        private void AnswerCorrect()
        {
            SelectedAnswer.AnswerCorrect();
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
    }
}
