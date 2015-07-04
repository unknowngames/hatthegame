using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets._scripts.UI.Controls;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Controls
{
    [AddComponentMenu("UI/ComboBox")]
    [SelectionBase]
    class ComboBox : UIBehaviour
    {
        private bool isOpen;

        [SerializeField]
        private Button headButton;

        [SerializeField]
        private ScrollList scrollList;

        public bool IsOpen
        {
            get
            {
                return isOpen;
            }
            set
            {
                isOpen = value;
            }
        }

        public ScrollList ScrollList
        {
            get
            {
                return scrollList;
            }
        }

        public Button HeadButton
        {
            get
            {
                return headButton;
            }
        }

        void OnEnable ()
        {
           base.OnEnable ();
        }

        
        void Update()
        {
            ScrollList.gameObject.SetActive (IsOpen);
        }

        public void SetIsOpen ()
        {
            isOpen = !isOpen;
        }
    }
}
