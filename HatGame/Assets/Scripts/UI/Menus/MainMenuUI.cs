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
    internal class MainMenuUI : UIWindow
    {
        [SerializeField]
        private ComboBox comboBox;

        [SerializeField]
        private ScrollList teamsScrollList;

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
                Team team = new Team ("1", "2", item.Button.GetComponentInChildren<Image> ());
                teamsScrollList.Add (team, item.Value.ToString ());
            }
        }
    }

    public class Team
    {
        private string playerOne;
        private string playerTwo;
        private Image teamIcon;

        public Team (string one, string two, Image icon)
        {
            PlayerOne = one;
            PlayerTwo = two;
            TeamIcon = icon;
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
    }

}
