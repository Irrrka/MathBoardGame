namespace MathGame.Services
{
    using MathGame.Common;
    using MathGame.Data;
    using MathGame.Services.Contracts;

    public class EmptyBoardGeneratorService : IEmptyBoardGeneratorService
    {
        public Square[,] GenerateEmptyBoard(int rows, int cols)
        {
            Square[,] board = new Square[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Square square = null;

                    if ((row + col) % Constants.BoardEl == 6)
                    {
                        square = new Square(row, col, "Yellow", new Empty(row, col));
                    }
                    else if ((row + col) % Constants.BoardEl == 5)
                    {
                        square = new Square(row, col, "Orange", new Empty(row, col));
                    }
                    else if ((row + col) % Constants.BoardEl == 4)
                    {
                        square = new Square(row, col, "Red", new Empty(row, col));
                    }
                    else if ((row + col) % Constants.BoardEl == 3)
                    {
                        square = new Square(row, col, "Violet", new Empty(row, col));
                    }
                    else if ((row + col) % Constants.BoardEl == 2)
                    {
                        square = new Square(row, col, "Indigo", new Empty(row, col));
                    }
                    else if ((row + col) % Constants.BoardEl == 1)
                    {
                        square = new Square(row, col, "Blue", new Empty(row, col));
                    }
                    else if ((row + col) % Constants.BoardEl == 0)
                    {
                        square = new Square(row, col, "Green", new Empty(row, col));
                    }

                    board[row, col] = square;
                }
            }

            return board;
        }
    }
}
