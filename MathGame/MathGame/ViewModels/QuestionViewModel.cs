using MathGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MathGame.ViewModels
{
    public class QuestionViewModel:ObservableObject
    {
        private QuizQuestion question;
        //need Id?

        //Question status
        //private bool isAnswered;
        private bool isCorrect;
        private bool isFailed;


        public QuestionViewModel(QuizQuestion model)
        {
            this.question = model;
            //this.Id = model.Id;
        }

        public string Question
        {
            get
            {
                return this.question.Question;
            }
        }

        public string Answer1
        {
            get
            {
                return this.question.Answer1;
            }
        }

        public string Answer2
        {
            get
            {
                return this.question.Answer2;
            }
        }

        public Color AnswerColor
        {
            get
            {
                if (this.IsFailed)
                    return Colors.Red;
                if (this.IsCorrect)
                    return Colors.Green;
                //if (this.IsAnswered)
                //    return Colors.Yellow;

                return Colors.Black;
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
                //OnPropertyChanged("SlideImage");
                OnPropertyChanged("AnswerColor");
            }
        }

        //Has been answered correct
        public bool IsCorrect
        {
            get
            {
                return this.isCorrect;
            }
            private set
            {
                this.isCorrect = value;
                //OnPropertyChanged("SlideImage");
                OnPropertyChanged("AnswerColor");
            }
        }

        //Is being answered by user
        //public bool IsAnswered
        //{
        //    get
        //    {
        //        return this.isAnswered;
        //    }
        //    private set
        //    {
        //        this.isAnswered = value;
        //        //OnPropertyChanged("SlideImage");
        //        OnPropertyChanged("AnswerColor");
        //    }
        //}

        public void AnswerCorrect()
        {
            this.IsCorrect = true;
        }

        public void AnswerFail()
        {
            this.IsFailed = true;
        }
    }
}
