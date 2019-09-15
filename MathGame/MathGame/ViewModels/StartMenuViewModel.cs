using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MathGame.ViewModels.GameViewModel;

namespace MathGame.ViewModels
{
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
            if (memoryGameName.Contains(gameString))
            {
                newGame = new MemoryGameViewModel();
            }
            if(quizGameName.Contains(gameString))
            {
                newGame = new QuizGameViewModel();
            }

            this.mainWindow.DataContext = newGame;
        }
    }
}
