using MathGame.Common;
using MathGame.Data;
using MathGame.Services.Contracts;

namespace MathGame.Services
{
    public class BoardGeneratorService : IBoardGeneratorService
    {
        Square[,] IBoardGeneratorService.Generate()
        {
            for (int row = 0; row < Constants.BoardRows; row++)
            {
                for (int col = 0; col < Constants.BoardCols; col++)
                {
                    Square square = null;
                }
            }
        }
    }
}
