namespace MathGame.Data
{
    public class User : BaseModel
    {
        public string Name { get; set; }

        public int HangmanScores { get; set; }
        public int QuizScores { get; set; }
        public int MemoryScores { get; set; }
        public int Scores { get; set; }
    }
}
