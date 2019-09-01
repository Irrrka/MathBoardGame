using System;
using System.Collections.Generic;
using System.Text;

namespace MathGame.Data
{
    public class Square : BaseModel
    {
        public string Color { get; set; }

        public MathTask MathTask { get; set; }

        public Position Position { get; set; }
    }
}
