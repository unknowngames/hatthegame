using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.UI.Controls;
using Assets._scripts.UI.Base;
using Assets._scripts.UI.Controls;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Assets.Scripts.UI.Menus
{
    internal class MainMenuUI : UIWindow
    {
        [SerializeField]
        private ComboBox comboBox;

        [SerializeField]
        private ScrollList teamsScrollList;
		private Team currentTeam;
		[SerializeField]
		public NextTeamEvent OnNextTeamEvent;

		[Serializable]
		public class NextTeamEvent : UnityEvent <Team> {}

		public void OnNextTeam()
		{
			OnNextTeamEvent.Invoke (currentTeam);
		}

        private void OnEnable ()
        {
            base.OnEnable ();
            if (comboBox != null)
            {
                for (int i = 1; i < 9; i++)
                {
                    comboBox.ScrollList.Add (i, i.ToString ());
                }
                comboBox.ScrollList.OnSelectedChanged += ChangeHeadButton;
				ChangeHeadButton (comboBox.ScrollList.Items[1]);
				UpdateTeamsList();
               // UpdateTeamsList();
            }

        }

        private void ChangeHeadButton (ListItem item)
        {
            if (Convert.ToInt32 (item.Value) > 1)
            {
                comboBox.HeadButton.GetComponentInChildren<Text> ().text =
                            item.Button.GetComponentInChildren<Text> ().text;
                UpdateTeamsList ();
            }
        }

        private void UpdateTeamsList ()
        {
            teamsScrollList.Clear ();
            int count = Convert.ToInt32 (comboBox.HeadButton.GetComponentInChildren<Text> ().text);
            for(int i=0; i < count; i++)
            {
                ListItem item = comboBox.ScrollList.Items[i];
				Team team = new Team ("Player1", "Player2", item.Button.GetComponentInChildren<Image> (), i+1);
				teamsScrollList.Add (team, team.PlayerOne, team.PlayerTwo, item.Button.GetComponentInChildren<Image> ().sprite);
            }
			currentTeam = teamsScrollList.Items [0].Value as Team;
        }


    }

}
