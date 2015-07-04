using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Object = System.Object;

namespace Assets._scripts.UI.Controls
{
    [AddComponentMenu("UI/ScrollList")]
    [SelectionBase]
    public class ScrollList : UIBehaviour, IScrollList
    {
        public event OnSelectedChanged OnSelectedChanged;

        [SerializeField] 
        private ScrollableContent content;

        [SerializeField] 
        // ReSharper disable once UnassignedField.Compiler
        private GameObject listItemPrefab;

        protected override void OnEnable()
        {           
            base.OnEnable ();
            if (content != null)
            {
                content.OnContentListItemClick += OnListItemOnClick;
                SetScrollBarVisibility ();
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable ();
            if (content != null)
            {
                content.OnContentListItemClick -= OnListItemOnClick;
            }
        }

        private void OnListItemOnClick(ListItem item)
        {
            OnSelectedChanged(item);
        }

        public IScrollListContent Content
        {
            get
            {
                if (content == null)
                {
                    content = GetComponentInChildren<ScrollableContent> ();
                }
                return content;
            }
        }

        public List<ListItem> Items
        {
            get
            {
                return Content.Items;
            }
        }

        public int Count
        {
            get
            {
                return Content.Count;
            }
        }

        public int Add (Object value, string text, Sprite image)
        {
            if (IsPrefab(listItemPrefab))
            {
                GameObject instance = InstantiateListItem(listItemPrefab);
                if (instance != null)
                {
                    TextAndImageScrollableListItem scrollableListItem = instance.GetComponent<TextAndImageScrollableListItem>();
                    if (scrollableListItem != null)
                    {
                        scrollableListItem.Value = value;
                        scrollableListItem.Text = text;
                        scrollableListItem.Image = image;

                        ListItem listItem = instance.GetComponent<ListItem>();
                        if (listItem != null)
                        {
                            int count = Content.Add(listItem);
                            SetScrollBarVisibility ();
                            return count;
                        }
                    }
                }
            }

            return -1;
        }

        public int Add(Object value, string text)
        {
            if (IsPrefab(listItemPrefab))
            {
                GameObject instance = InstantiateListItem(listItemPrefab);
                if (instance != null)
                {
                    TextScrollableListItem scrollableListItem = instance.GetComponent<TextScrollableListItem>();
                    if (scrollableListItem != null)
                    {
                        scrollableListItem.Value = value;
                        scrollableListItem.Text = text;

                        ListItem listItem = instance.GetComponent<ListItem>();
                        if (listItem != null)
                        {
                            int count = Content.Add(listItem);
                            SetScrollBarVisibility();
                            return count;
                        }
                    }
                }
            }

            return -1;
        }

        public void Remove(Object value)
        {
            ListItem item = Content.Items.Find(x => x.Value == value);
            if (item != null)
            {
                Content.Remove(item);
                Destroy(item.gameObject); 
            }
        }

        public void RemoveAt (int index)
        {
            Content.RemoveAt(index);
            Destroy(Items[index].gameObject); 
        }

        public void Clear ()
        {
            foreach (ListItem item in Items)
            {
                Destroy(item.gameObject); 
            }
            Content.Clear ();
        }

        private GameObject InstantiateListItem(GameObject gameObject)
        {
            if (IsPrefab(gameObject))
            {
                GameObject instance = Instantiate(gameObject) as GameObject;
                instance.transform.SetParent(content.gameObject.transform, false);
                return instance;
            }
            return gameObject;
        }

        private bool IsPrefab(GameObject go)
        {
            var tempObject = new GameObject();
            try
            {
                if (go != null)
                {
                    tempObject.transform.parent = go.transform.parent;

                    var originalIndex = go.transform.GetSiblingIndex();

                    go.transform.SetSiblingIndex(int.MaxValue);
                    if (go.transform.GetSiblingIndex() == 0) return true;

                    go.transform.SetSiblingIndex(originalIndex);
                    return false;
                }
            }
            finally
            {
                DestroyImmediate(tempObject);
            }
            return false;
        }

        private void SetScrollBarVisibility ()
        {
           if (listItemPrefab != null)
            {
                if (Count == 0)
                {
                    transform.FindChild("ScrollBar").gameObject.SetActive(false);
                    return;
                }
                float elementSize = Content.Items[0].GetComponent<LayoutElement> ().minHeight;
                float bar = transform.transform.GetComponent<RectTransform> ().rect.height;
                if (bar >= elementSize*Count)
                {
                    transform.FindChild ("ScrollBar").gameObject.SetActive (false);
                }
                else
                {
                    transform.FindChild("ScrollBar").gameObject.SetActive(true);
                }
            }
        }
    }
}