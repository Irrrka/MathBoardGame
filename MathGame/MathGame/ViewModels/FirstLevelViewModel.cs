using MathGame.Common;
using MathGame.Data;
using MathGame.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MathGame.ViewModels
{
    public class FirstLevelViewModel
    {
        private readonly IEmptyBoardGeneratorService generatorService;
        private ICommand initCommand;
        private Square[,] board;

        public FirstLevelViewModel(IEmptyBoardGeneratorService generatorService)
        {
            this.generatorService = generatorService;
            this.Squares = new ObservableCollection<Square>();
        }

        public ObservableCollection<Square> Squares { get; set; }

        public ICommand InitCommand
        {
            get
            {
                if (initCommand == null)
                {
                    initCommand = new RelayCommand<object>(Init);
                }
                return initCommand;
            }
        }

        public void Init(object data)
        {
            var board = this.generatorService.GenerateEmptyBoard(Constants.BoardRows, Constants.BoardCols);

            foreach (var square in board)
            {
                this.Squares.Add(square);
            }
        }
    }
}
