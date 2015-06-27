using HatGameLibrary.Interfaces;
using HatGameLibrary.Internal;

namespace HatGameLibrary.Public
{
    public static class HatGameBuilder
    {
        public static IHatGame Create(IGameView gameView, IWordProvider wordProvider)
        {
            return new HatGame(gameView, wordProvider);
        }
    }
}