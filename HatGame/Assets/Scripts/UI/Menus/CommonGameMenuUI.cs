using UnityEngine;
using System.Collections;
using Assets._scripts.UI.Base;
using UnityEngine.UI;

public class CommonGameMenuUI : UIWindow
{
    [SerializeField]
    private Text word;

    public void SetWord (string localword)
    {
        word.text = localword;
    }
}
