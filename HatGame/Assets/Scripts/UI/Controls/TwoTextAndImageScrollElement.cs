using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets._scripts.UI.Controls
{
	public class TwoTextAndImageScrollElement : ListItem
	{

		[SerializeField]
		// ReSharper disable once UnassignedField.Compiler
		private Image image;
	
		public Sprite Image
		{
			get { return image.sprite; }
			set { image.sprite = value; }
		}

		[SerializeField] 
		// ReSharper disable once UnassignedField.Compiler
		private Text text1;
		
		public string Text1
		{
			set 
			{
				if (text1 != null)
				{
					text1.text = value;
				}
			}
		}
		[SerializeField] 
		// ReSharper disable once UnassignedField.Compiler
		private Text text2;
		
		public string Text2
		{
			set 
			{
				if (text2 != null)
				{
					text2.text = value;
				}
			}
		}
	}
}
