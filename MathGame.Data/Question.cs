using System;
using System.Collections.Generic;
using System.Text;

namespace MathGame.Data
{
    public class QuizQuestion : BaseModel
    {
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
