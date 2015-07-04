using UnityEngine;
using UnityEngine.UI;

namespace Assets._scripts.UI.Controls
{
    public class TextAndImageScrollableListItem : TextScrollableListItem
    {
        [SerializeField]
        // ReSharper disable once UnassignedField.Compiler
        private Image image;

        public Sprite Image
        {
            get { return image.sprite; }
            set { image.sprite = value; }
        }
    }
}