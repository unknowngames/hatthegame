using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets._scripts.UI.Controls
{
    public class UIButton : UIBehaviour
    {
        [SerializeField]
        private Button button;
        [SerializeField]
        private Text textControl;
        [SerializeField]
        private Image imageControl;

        [SerializeField]
        public UIButtonClickedEvent OnClick;

        public string Text
        {
            get
            {
                return textControl.text;
            }
            set
            {
                textControl.text = value;
            }
        }

        public Sprite Image
        {
            get
            {
                return imageControl.sprite;
            }
            set
            {
                imageControl.sprite = value;
            }
        }

        [Serializable]
        public class UIButtonClickedEvent : UnityEvent
        {
        }

        protected override void OnEnable ()
        {
            base.OnEnable ();
            button.onClick.AddListener(OnButtonClick);
        }

        protected override void OnDisable ()
        {
            base.OnDisable ();

            button.onClick.RemoveListener(OnButtonClick);
        }

        public void OnButtonClick()
        {
            OnClick.Invoke ();
        }
    }
}
