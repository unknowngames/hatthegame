using System;
using System.Text;
using Assets._scripts.UI.Base;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.HatGameUnity;

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

		public void SetCurrentTeam(Team team)
		{
			currentTeam = team;
		}

		void OnEnable()
		{
			base.OnEnable ();
			player1.text = currentTeam.PlayerOne;
			player2.text = currentTeam.PlayerTwo;
			icon.sprite = currentTeam.TeamIcon.sprite;
		}

		void Update()
		{
			if (currentTeam != null && scores != null && gameView != null) 
			{
				scores.text = (currentTeam.Scores + gameView.Points).ToString();
			}
		}

    }
}
