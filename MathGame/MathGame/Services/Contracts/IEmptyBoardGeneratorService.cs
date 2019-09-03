using MathGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.Services.Contracts
{
    public interface IEmptyBoardGeneratorService
    {
        Square[,] GenerateEmptyBoard(int rows, int cols);
    }
}
