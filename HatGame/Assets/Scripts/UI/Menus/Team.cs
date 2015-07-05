using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.UI.Controls;
using Assets._scripts.UI.Base;
using Assets._scripts.UI.Controls;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Menus
{

    public class Team
    {
        private string playerOne;
        private string playerTwo;
        private Image teamIcon;
		private int teamNumber;
		private int scores = 0;

        public Team (string one, string two, Image icon, int number)
        {
            PlayerOne = one;
            PlayerTwo = two;
            TeamIcon = icon;
			teamNumber = number;
        }

        public string PlayerOne
        {
            get
            {
                return playerOne;
            }
            set
            {
                playerOne = value;
            }
        }

        public string PlayerTwo
        {
            get
            {
                return playerTwo;
            }
            set
            {
                playerTwo = value;
            }
        }

        public Image TeamIcon
        {
            get
            {
                return teamIcon;
            }
            set
            {
                teamIcon = value;
            }
        }

		public int Scores
		{
			get 
			{
				return scores;
			}
			set 
			{
				scores = value;
			}
		}
    }

}
