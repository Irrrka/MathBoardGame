using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.Services.Contracts
{
    public interface IHangmanService
    {
        string GetWord();

        char[] ShowLetters();
    }
}
