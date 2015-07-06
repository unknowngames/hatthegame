using System;
using HatGameLibrary.Interfaces;
using HatGameLibrary.Public;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts.HatGameUnity
{
	public class GameView : MonoBehaviour, IGameView
	{
		[SerializeField] private Text timeLeft;
		[SerializeField] private Text score;
		[SerializeField] private Text word;
		private string wordArea;
		private int points = 0;
		private TimeSpan lastTime;

	    public bool IsStarted { get; set; }

		public string WordArea
		{
			get { return wordArea; }
			set
			{
				wordArea = value;
				word.text = wordArea;
			}
		}

		public int Points
		{
			get { return points; }
			set
			{
				points = value;
				score.text = "Score: " + points;
			}
		}

		public TimeSpan LastTime
		{
			get { return lastTime; }
			set
			{
				lastTime = value;
			    timeLeft.text = "Time Left: " + lastTime.Minutes + ":" + lastTime.Seconds;
			}
		}

		public event OnClickDelegate Guessed;
		public event OnClickDelegate NotGuessed;

		private void CallGuessed()
		{
			OnClickDelegate handler = Guessed;
			if (handler != null)
			{
				handler();
			}
		}

		private void CallNotGuessed()
		{
			OnClickDelegate handler = NotGuessed;
			if (handler != null)
			{
				handler();
			}
		}

		public void OnGuessedClick()
		{
			CallGuessed();
		}

		public void OnNotGuessedClick()
		{
			CallNotGuessed();
		}
	}
}
