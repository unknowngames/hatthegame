using System.Collections.Generic;

namespace Assets._scripts.UI.Controls
{
    public interface IScrollListContent
    {
        List<ListItem> Items { get; }
        int Count { get; }
        int Add(ListItem item);
        void Remove(ListItem item);
        void RemoveAt(int index);
        void Clear();
    }
}