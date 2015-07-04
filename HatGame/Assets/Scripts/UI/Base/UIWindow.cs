using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Assets._scripts.UI.Base
{
    public abstract class UIWindow : UIBehaviour
    {
        [SerializeField]
        public OnShow OnShowEvent;
        [SerializeField]
        public OnHide OnHideEvent;
        [SerializeField]
        public OnBack OnBackEvent;

        [Serializable]
        public class OnShow : UnityEvent<UIWindow>
        {
        }

        [Serializable]
        public class OnHide : UnityEvent<UIWindow>
        {
        }

        [Serializable]
        public class OnBack : UnityEvent<UIWindow>
        {
        }
      
        public void Show ()
        {
            gameObject.SetActive (true);
            OnShown();
            OnShowEvent.Invoke(this);
        }

        public void Hide ()
        {
            gameObject.SetActive (false);
            OnClosed();
            OnHideEvent.Invoke (this);
        }

        public void Back ()
        {
            gameObject.SetActive(false);
            OnClosed();
            OnBackEvent.Invoke(this); 
        }

        protected virtual void OnShown() { }
        protected virtual void OnClosed() { }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Hide();
            }
        }
    }
}