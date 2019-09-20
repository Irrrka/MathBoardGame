namespace MathGame.ViewModels
{
    using MathGame.ViewModels.HangmanGame;

    public class StartMenuViewModel
    {
        private MainWindow mainWindow;
        public StartMenuViewModel(MainWindow main)
        {
            this.mainWindow = main;
            SoundManager.PlayBackgroundMusic();
        }

        public void StartNewGame(int gameIndex)
        {
            GameType game = (GameType)gameIndex;
            var gameString = game.ToString().ToLower();
            GameViewModel newGame = null;
            //TODO Reflection
            var memoryGameName = (nameof(MemoryGameViewModel)).ToLower();
            var quizGameName = (nameof(QuizGameViewModel)).ToLower();
            var hangmanGameName = (nameof(HangmanGameViewModel)).ToLower();
            if (memoryGameName.Contains(gameString))
            {
                newGame = new MemoryGameViewModel();
            }
            if(quizGameName.Contains(gameString))
            {
                newGame = new QuizGameViewModel();
            }
            if (hangmanGameName.Contains(gameString))
            {
                newGame = new HangmanGameViewModel();
            }

            this.mainWindow.DataContext = newGame;
        }
    }
}
