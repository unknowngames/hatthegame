using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets._scripts.UI.Controls
{
    public abstract class ListItem : UIBehaviour
    {                          
        private Object value;

        public Object Value
        {
            set
            {
                this.value = value;
            }
            get
            {
                return value;
            }
        }

        public event OnListItemClick OnClick;
        public Button Button;

        protected override void OnEnable()
        {
            base.OnEnable();
            if (Button != null)
            {
                Button.onClick.AddListener(Click);
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable ();
            if (Button != null)
            {
                Button.onClick.RemoveListener(Click);
            }
        }    

        protected void Click()
        {
            if (OnClick != null)
            {
                OnClick(this);
            }
        }
    }
}