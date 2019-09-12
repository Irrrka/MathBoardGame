using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void StartNewGame()
        {
            GameViewModel newGame = new GameViewModel();
            this.mainWindow.DataContext = newGame;
        }
    }
}
