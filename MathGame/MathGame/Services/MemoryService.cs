
namespace MathGame.Services
{
    using MathGame.Data;
    using MathGame.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class MemoryService : IMemoryService
    {
        public List<Image> GetModelsFrom(string relativePath)
        {
            var models = new List<Image>();
            string[] images = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, @"Resources\Images"));
            var id = 0;

            foreach (string i in images)
            {
                models.Add(new Image() { Id = id, Path = i });
                id++;
            }

            return models;
        }
    }
}
