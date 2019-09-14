using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.Common
{
   public static class Constants
    {
        //Board
        public const int BoardRows = 1;
        public const int BoardCols = 3;
        public const int BoardEl = 3;

        //BoardColors
        public const string White = "White";
        public const string Yellow = "Yellow";
        public const string Orange = "Orange";
        public const string Red = "Red";
        public const string Violet = "Violet";
        public const string Indigo = "Indigo";
        public const string Blue = "Blue";
        public const string Green = "Green";

        //MemoryGame
        public const int memoAttempts = 3;
        public const int pointAward = 75;
        public const int pointLoss = 15;
        public const int playSeconds = 1;
        public const int peekSeconds = 2;
        public const int openSeconds = 5;


        //Quiz QA
        public const string q1 = "Как се казва Островът от сериала?";
        public const string a11 = "Пиратският остров";
        public const string a12 = "Островът на сините птици";

        public const string q2 = "Кои са децата, които достигат Острова";
        public const string a21 = "Ники, Алекс, Габи и Армандо";
        public const string a22 = "Ники, Алекс, Габи, Армандо и Зоица";

    }
}
