using System;
using Assets.Scripts.HatGameUnity;
using Assets._scripts.UI.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Menus
{
    class GameMenuUI : UIWindow
    {
		Team currentTeam;
		[SerializeField]
		Text player1;
		[SerializeField]
		Text player2;
		[SerializeField]
		Image icon;
		[SerializeField]
		Text scores;
		[SerializeField]
		GameView gameView;
        [SerializeField]
        public EndRoundEvent OnEndRoundEvent;


        [Serializable]
        public class EndRoundEvent : UnityEvent<string> { }

        
        public void SetCurrentTeam(Team team)
		{
			currentTeam = team;
		}

		void OnEnable()
		{
			base.OnEnable ();
			if (currentTeam != null) 
			{
				player1.text = currentTeam.PlayerOne;
				player2.text = currentTeam.PlayerTwo;
				icon.sprite = currentTeam.TeamIcon.sprite;
			}
		}

		void Update()
		{
			if (currentTeam != null && scores != null && gameView != null) 
			{
				scores.text = (currentTeam.Scores + gameView.Points).ToString();
			}
            if (gameView != null && gameView.LastTime.Seconds <= 0)
		    {
                OnEndRound(gameView.WordArea);
		    }
		}

        private void OnEndRound (string text)
        {
            OnEndRoundEvent.Invoke(text);
        }


    }
}
