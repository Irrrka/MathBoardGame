namespace MathGame.Services.Contracts
{
    using MathGame.Data;
    using MathGame.ViewModels;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public interface IQuizService
    {
        List<QuizQuestion> GenerateQuizQuestions();

        ObservableCollection<QuestionViewModel> CreateQuiz(List<QuizQuestion> quizQuestions);
    }
}
