using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.UI.Menus;
using Assets._scripts.UI.Base;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI
{
    class MenuUI : UIBehaviour
    {
        private UIWindow[] windows;

        protected override void OnEnable()
        {
            base.OnEnable();

            windows = GetComponentsInChildren<UIWindow>();

            foreach (UIWindow uiWindow in windows)
            {
                if (uiWindow is MainMenuUI)
                {
                    uiWindow.Show();
                }
                else
                {
                    uiWindow.Hide();
                }
            }
        }
    }
}
