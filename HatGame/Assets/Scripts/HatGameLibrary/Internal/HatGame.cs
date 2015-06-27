using System;
using HatGameLibrary.Interfaces;

namespace HatGameLibrary.Internal
{
    internal class HatGame : IHatGame
    {
        private readonly IGameView gameView;
        private readonly IWordProvider wordProvider;

        private TimeSpan lastTime;
        private int points;

        public HatGame(IGameView gameView, IWordProvider wordProvider)
        {
            this.gameView = gameView;
            this.wordProvider = wordProvider;
        }

        public void BeginGame()
        {
            Reset();

            gameView.Guessed += Guessed;
            gameView.NotGuessed += NotGuessed;
        }

        public void StopGame()
        {
            Reset();

            gameView.Guessed -= Guessed;
            gameView.NotGuessed -= NotGuessed;
        }

        public void Update(TimeSpan deltaTime)
        {
            lastTime -= deltaTime;
            gameView.LastTime = lastTime;
        }

        private void Guessed()
        {
            points++;
            gameView.Points = points;

            ApplyNextWord();
        }

        private void NotGuessed()
        {
            ApplyNextWord();
        }

        private void ApplyNextWord()
        {
            string nextWord = wordProvider.GetNextWord();
            gameView.WordArea = nextWord;
        }

        private void Reset()
        {
            lastTime = TimeSpan.FromSeconds(40);
            points = 0;
        }
    }
}
