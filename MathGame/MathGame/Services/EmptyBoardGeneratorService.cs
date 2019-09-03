namespace MathGame.Services
{
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

                    if ((row + col) % 7 == 0)
                    {
                        square = new Square(row, col, "Yellow", new Empty(row, col));
                    }
                    else if ((row + col) % 7 == 1)
                    {
                        square = new Square(row, col, "Orange", new Empty(row, col));
                    }
                    else if ((row + col) % 7 == 2)
                    {
                        square = new Square(row, col, "Red", new Empty(row, col));
                    }
                    else if ((row + col) % 7 == 3)
                    {
                        square = new Square(row, col, "Violet", new Empty(row, col));
                    }
                    else if ((row + col) % 7 == 4)
                    {
                        square = new Square(row, col, "Indigo", new Empty(row, col));
                    }
                    else if ((row + col) % 7 == 5)
                    {
                        square = new Square(row, col, "Blue", new Empty(row, col));
                    }
                    else if ((row + col) % 7 == 6)
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
