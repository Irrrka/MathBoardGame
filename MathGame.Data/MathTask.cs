namespace MathGame.Data
{
    public class MathTask : BasePositionModel
    {
        public MathTask(int row, int col, string image = null, string problem = null)
        {
            this.Row = row;
            this.Col = col;
            this.Image = image;
            this.Problem = problem;
        }

        public string Problem { get; set; }

        public string Image { get; set; }
    }
}