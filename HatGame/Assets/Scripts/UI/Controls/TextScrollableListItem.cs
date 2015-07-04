using UnityEngine;
using UnityEngine.UI;

namespace Assets._scripts.UI.Controls
{
    public class TextScrollableListItem : ListItem
    {
        [SerializeField] 
        // ReSharper disable once UnassignedField.Compiler
        private Text text;

        public string Text
        {
            set 
            {
                if (text != null)
                {
                    text.text = value;
                }
            }
        }
    }
}