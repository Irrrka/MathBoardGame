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
        private ICommand dragInitCommand;
        private ICommand dragOverCommand;
        private Square[,] board;
        private MathTask selectedMathTask;

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

        public ICommand DragInitCommand
        {
            get
            {
                if (dragInitCommand == null)
                {
                    dragInitCommand = new RelayCommand<MathTask>(DragInit);
                }
                return dragInitCommand;
            }
        }

        public ICommand DragOverCommand
        {
            get
            {
                if (dragOverCommand == null)
                {
                    dragOverCommand = new RelayCommand<MathTask>(DragOver);
                }
                return dragOverCommand;
            }
        }

        public void Init(object data)
        {
            this.board = this.generatorService.GenerateEmptyBoard(Constants.BoardRows, Constants.BoardCols);

            foreach (var square in board)
            {
                this.Squares.Add(square);
            }
        }
        public void DragInit(MathTask task)
        {
            Task.Run(() =>
            {
                MessageBox.Show(task.ToString());
            });
           
        }
        public void DragOver(MathTask task)
        {
            var selectedSquare = board[selectedMathTask.Row, selectedMathTask.Col];
            var destinationSquare = board[task.Row, task.Col];

            var indexOfSelectedSquare = Squares.IndexOf(selectedSquare);
            var indexOfDestinationSquare = Squares.IndexOf(destinationSquare);

            var newSelectedSquare = new Square(
                selectedSquare.Row,
                selectedSquare.Col,
                selectedSquare.Color,
                new Empty(selectedSquare.Row, selectedSquare.Col));

            Squares[indexOfSelectedSquare] = newSelectedSquare;

            selectedMathTask.Row = destinationSquare.Row;
            selectedMathTask.Col = destinationSquare.Col;

            var newDestinationSwuare = new Square(
               destinationSquare.Row,
               destinationSquare.Col,
               destinationSquare.Color,
               selectedMathTask);

            Squares[indexOfDestinationSquare] = newDestinationSwuare;

            this.board[selectedSquare.Row, selectedSquare.Col] = newSelectedSquare;
            this.board[destinationSquare.Row, destinationSquare.Col] = newDestinationSwuare;

            Task.Run(() =>
            {
                MessageBox.Show(task.ToString());
            });
        }
    }
}
