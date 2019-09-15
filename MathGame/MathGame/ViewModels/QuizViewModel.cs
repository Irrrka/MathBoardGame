using MathGame.Data;
using MathGame.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MathGame.ViewModels
{
    public class QuizViewModel:ObservableObject
    {
        private List<QuizQuestion> quiz;
        private IQuizSevice quizService;
        private ICommand quizQuestionsCommand;
        private ICommand createQuizCommand;

        
        //Question status
        private bool isAnswered;
        private bool isCorrect;
        private bool isFailed;

        public QuizViewModel(IQuizSevice quizService)
        {
            this.Quiz = new ObservableCollection<QuestionViewModel>();
            this.quizService = quizService;
        }
        public QuizViewModel()
        {
        }

        public ObservableCollection<QuestionViewModel> Quiz { get; set; }

        public QuestionViewModel SelectedAnswer;
        public QuestionViewModel CorrectAnswer;



        public ICommand QuizQuestionsCommand
        {
            get
            {
                if (this.quizQuestionsCommand == null)
                {
                    this.quizQuestionsCommand = new RelayCommand<object>(QuizQuestions);
                }
                return this.quizQuestionsCommand;
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

        public void QuizQuestions(object data)
        {
            this.quiz = this.quizService.GenerateQuizQuestions();
        }

        public void CreateQuiz(object data)
        {
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

        //Are the selected slides a match

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
