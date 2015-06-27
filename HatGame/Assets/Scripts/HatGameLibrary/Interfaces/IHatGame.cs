using System;

namespace HatGameLibrary.Interfaces
{
    public interface IHatGame
    {
        void BeginGame();
        void StopGame();
        void Update(TimeSpan deltaTime);
    }
}