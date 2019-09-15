namespace MathGame.Services
{
    using MathGame.Data;
    using MathGame.Services.Contracts;
    using MathGame.ViewModels;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.IO;
    using System.Text;

    public class QuizService : IQuizService
    {
        public List<QuizQuestion> GenerateQuizQuestions()
        {
            var questions = new List<QuizQuestion>();

            //using (StreamReader file = new StreamReader(@"Common/Questions.json"))
            //{
            //    var jsonString = file.ReadToEnd();
            //    byte[] encodedBytes = Encoding.UTF8.GetBytes(jsonString);
            //    //Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);

            //    var encoded = Encoding.UTF8.GetString(encodedBytes);

            //    questions = JsonConvert
            //        .DeserializeObject<List<QuizQuestion>>(
            //        encoded, 
            //        new JsonSerializerSettings()
            //            {
            //                Culture = CultureInfo.InvariantCulture
            //            });

            //    //string json = file.ReadToEnd();
            //    //questions = JsonConvert.DeserializeObject<List<QuizQuestion>>(json);
            //}

            var data = new QuizData();
            var args = data.qaData;
            for (int i = 0; i < args.GetLength(0); i++)
            {
                questions.Add
                    (
                    new QuizQuestion
                        {
                            Question = args[i, 0],
                            Answer1 = args[i, 1],
                            Answer2 = args[i, 2],
                            CorrectAnswer = args[i, 3],
                        }
                    );
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
