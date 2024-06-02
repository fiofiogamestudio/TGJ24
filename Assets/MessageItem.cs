using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MessageItem : MonoBehaviour, IPointerClickHandler
{
    [ReadOnly]
    public string number;
    [ReadOnly]
    public string timeStr;
    [ReadOnly]
    public string content;

    public Text numberText;
    public Text timeText;
    public Text contentText;


    [ReadOnly]
    public AppMessage referenceApp;

    public void Init(MessageInfo info, AppMessage reference)
    {
        this.number = info.number;
        switch (info.previewType)
        {
            case 0:
                this.timeStr = info.day;
            break;
            case 1:
                this.timeStr = info.dayOfWeek;
            break;
            case 2:
                this.timeStr = info.timeOfDay;
            break;
            case 3:
                this.timeStr = "昨天";
            break;
        }

        this.content = info.content;

        this.referenceApp = reference;
        refreshView();
    }


    void refreshView()
    {
        this.numberText.text = this.number;
        this.timeText.text = this.timeStr;
        this.contentText.text = this.content;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        referenceApp.SelectItem(this);
        throw new System.NotImplementedException();
    }
}
