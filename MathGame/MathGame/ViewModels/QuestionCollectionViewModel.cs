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


    }
}
