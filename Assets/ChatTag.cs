using System.Collections;
using System.Collections.Generic;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChatTag : MonoBehaviour, IPointerClickHandler
{
    [ReadOnly]
    public string chatName;
    [ReadOnly]
    public Sprite sprite;
    [ReadOnly]
    public string content;
    [ReadOnly]
    public int chatTarget;
    [ReadOnly]
    public List<ChatItemInfo> itemList;

    public Text nameText;
    public Text contentText;
    public Image portraitIamge;

    [ReadOnly]
    public AppChat referenceApp;

    public void Init(ChatRecord record, AppChat reference)
    {
        this.chatName = record.name;
        this.sprite = PortraitHolder.instance.getPortrait(this.chatName);
        if (record.itemList.Count != 0)
        {
            this.content = record.itemList[0].content;
        }
        else
        {
            this.content = "";
        }

        this.chatTarget = record.chatTarget;
        this.itemList = record.itemList;

        this.referenceApp = reference;

        refreshView();
        
    }


    void refreshView()
    {
        this.nameText.text = this.chatName;
        this.contentText.text = this.content;
        this.portraitIamge.sprite = this.sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        this.referenceApp.SelectChat(this);
        // // 进行射线检测
        // List<RaycastResult> results = new List<RaycastResult>();
        // EventSystem.current.RaycastAll(eventData, results);

        // var result = results[0];
        // if (result.gameObject == gameObject)
        // {
        //     // 处理点击事件
        //     if (GameManager.instance.interactMode == GameInteractMode.Interact)
        //     {
        //     }
        // }
    }
    
}
