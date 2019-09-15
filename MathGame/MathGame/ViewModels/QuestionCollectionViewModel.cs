using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.ViewModels
{
    public class QuestionCollectionViewModel : ObservableObject
    {
        public ObservableCollection<QuestionViewModel> Questions { get; private set; }

        private void ShuffleQuestions()
        {
            var rnd = new Random();

            for (int i = 0; i < (this.Questions.Count * this.Questions.Count); i++)
            {
                this.Questions.Reverse();
                this.Questions.Move(rnd.Next(0, this.Questions.Count), rnd.Next(0, this.Questions.Count));
            }
        }
    }
}
