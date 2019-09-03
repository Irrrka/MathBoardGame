using System;
using System.Collections.Generic;
using System.Text;

namespace MathGame.Data
{
    public class Square : BasePositionModel
    {
        public Square(int row, int col, string color, MathTask mathTask = null)
        {
            this.Row = row;
            this.Col = col;
            this.Color = color;
            this.MathTask = mathTask;
        }

        public string Color { get; set; }

        public MathTask MathTask { get; set; }

    }
}
