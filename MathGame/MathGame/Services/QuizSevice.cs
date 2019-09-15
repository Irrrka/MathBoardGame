namespace MathGame.Services
{
    using MathGame.Data;
    using MathGame.Services.Contracts;
    using MathGame.ViewModels;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;

    public class QuizSevice : IQuizSevice
    {
        public List<QuizQuestion> GenerateQuizQuestions()
        {
            List<QuizQuestion> questions = new List<QuizQuestion>();

            using (StreamReader file = new StreamReader("/MathGame;component/Resources/back_image.jpg"))
            {
                string json = file.ReadToEnd();
                questions = JsonConvert.DeserializeObject<List<QuizQuestion>>(json);
            }

            return questions;
        }

        //Create quiz from quizQuestions
        public ObservableCollection<QuestionViewModel> CreateQuiz(List<QuizQuestion> quizQuestions)
        {
            var quiz = new ObservableCollection<QuestionViewModel>();

            for (int i = 0; i < quizQuestions.Count; i++)
            {
                var question = new QuestionViewModel(quizQuestions[i]);
                quiz.Add(question);
            }

            return quiz;
        }


    }
}
