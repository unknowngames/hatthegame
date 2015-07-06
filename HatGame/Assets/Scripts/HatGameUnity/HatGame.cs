using System;
using HatGameLibrary.Interfaces;
using HatGameLibrary.Public;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts.HatGameUnity
{
	public class HatGame : MonoBehaviour
	{
		[SerializeField] private GameView gameView;

		private static IHatGame hatGame;

		public void BeginGame()
		{
			IWordProvider wordProvider = WordProviderBuilder.Create();
			hatGame = HatGameBuilder.Create(gameView, wordProvider);
			hatGame.BeginGame();
		}

		void Update()
		{
		    if (gameView.IsStarted)
		    {
		        var leftTime = TimeSpan.FromSeconds (Time.deltaTime);
		        hatGame.Update (leftTime);
		    }
		}

		public void SetPositiveButton()
		{
			gameView.OnGuessedClick();
		}

		public void SetNegativeButton()
		{
			gameView.OnNotGuessedClick();
		}
	}
}