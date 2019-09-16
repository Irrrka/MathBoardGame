using MathGame.Data;
using MathGame.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.Services
{
    public class HangmanService : IHangmanService
    {
        private HangmanData data;
        private string word;
        private int lenght;
        private int stage;
        private Image image;

        public HangmanService()
        {
            this.data = new HangmanData();
            this.stage = 0;
            this.image = new Image();
        }

        public string GetWord()
        {
            var wordStr = data.wordsData;
            Random rnd = new Random();
            this.word = wordStr[rnd.Next(0,wordStr.Length)];
            this.lenght = this.word.Length;

            return word;
        }

        public char[] ShowLetters()
        {
            var letterStr = data.lettersData;

            return letterStr;
        }

        public int[] TakeCharachter(char letter)
        {
            int[] temp = new int[this.word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                if (this.word.ToUpper()[i] == letter)
                {
                    temp[i] = 1;
                }
                else
                {
                    temp[i] = 0;
                    this.stage++;
                }

                //if (temp.Count(i => i == 1) == 0)
                //{
                //    Stage++;
                //}
            }

            return temp;
        }

        public string GetStageImage()
        {
            string[] images = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, @"Resources\Hangman"));
            return images.FirstOrDefault(c=>c.Contains(this.stage.ToString()));
        }

        public bool IsGameOver()
        {
            return this.stage >= 7 ? true : false;
        }
    }
}
