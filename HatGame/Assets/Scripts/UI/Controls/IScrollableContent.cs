using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

namespace Assets._scripts.UI.Controls
{
    public interface IScrollList
    {
        List<ListItem> Items { get; }
        int Count { get; }
        int Add(Object value, string text, string text2, Sprite image);
        int Add(Object value, string text);
        void Remove(Object value);
        void RemoveAt(int index);
        void Clear();
    }
}