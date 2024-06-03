using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class OtherChatItem : MonoBehaviour
{
    public Image portraitImage;
    public TextMeshProUGUI contentText;

    public void InitView(Sprite sprite, string content, string time)
    {
        this.portraitImage.sprite = sprite;
        this.contentText.text = content;
        this.contentText.GetComponent<AutoWrapTextMeshPro>().UpdateTextWidth();
    }
}
