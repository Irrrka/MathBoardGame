using MathGame.Data;
using System.Collections.Generic;

namespace MathGame.Services.Contracts
{
    public interface IMemoryService
    {
        List<Image> GetModelsFrom(string relativePath);
    }
}
