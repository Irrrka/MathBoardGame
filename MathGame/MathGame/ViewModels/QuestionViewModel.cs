using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MathGame.ViewModels
{
    public class QuestionViewModel:ObservableObject
    {
        private ICommand quizCommand;

        public ICommand QuizCommand
        {
            get
            {
                if (quizCommand == null)
                {
                    quizCommand = new RelayCommand<object>(Quiz);
                }
                return quizCommand;
            }
        }

        public void Quiz(object data)
        {
            //this.board = this.generatorService.GenerateEmptyBoard(Constants.BoardRows, Constants.BoardCols);

            //foreach (var square in board)
            //{
            //    this.Squares.Add(square);
            //}
        }
    }
}
