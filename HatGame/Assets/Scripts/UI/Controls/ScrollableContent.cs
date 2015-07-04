using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Assets._scripts.UI.Controls
{
    public class ScrollableContent : UIBehaviour, IScrollListContent
    {
        public event OnListItemClick OnContentListItemClick;
        private List<ListItem> items = new List<ListItem>();

        protected override void Start ()
        {
            base.Start();
            foreach (ListItem item in Items)
            {
                item.OnClick += OnContentListItemOnClick;
            }
        }

        private void OnContentListItemOnClick(ListItem item)
        {
            OnContentListItemClick(item);
        }

        public List<ListItem> Items
        {
            get
            {
                return items;
            }
        }

        public int Count
        {
            get
            {
                return items.Count;
            }
        }

        public int Add(ListItem item)
        {
            items.Add(item);
            item.OnClick += OnContentListItemOnClick;

            return items.IndexOf(item);
        }

        public void Remove(ListItem item)
        {
            items.RemoveAll(listItem => listItem.Button == item.Button);
            item.OnClick -= OnContentListItemOnClick;
        }

        public void RemoveAt(int index)
        {
            if (items.Count > index)
            {
                ListItem item = items[index];
                item.OnClick -= OnContentListItemOnClick;
                items.RemoveAt(index);
            }
        }

        public void Clear()
        {
            foreach (ListItem item in items)
            {
                item.OnClick -= OnContentListItemOnClick;
            }

            items.Clear ();
        }
    }
}
