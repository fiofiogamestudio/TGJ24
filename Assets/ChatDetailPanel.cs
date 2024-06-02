using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatDetailPanel : MonoBehaviour
{
    public Text DetailName;
    
    public GameObject OtherChatItemPrefab;
    public GameObject MeChatItemPrefab;

    public Transform DetailRoot;

    public Button TalkButton;

    public int chatTarget;
    void Awake()
    {
        TalkButton.onClick.AddListener(()=>{
            DialogUIManager.instance.LoadDialog(chatTarget);
        });
    }

    public void ClearDetail()
    {
        while (DetailRoot.childCount != 0)
        {
            GameObject.DestroyImmediate(DetailRoot.GetChild(0).gameObject);
        }
    }

    public void RefreshDetail(ChatTag tag)
    {
        DetailName.text = tag.chatName;

        while (DetailRoot.childCount != 0)
        {
            GameObject.DestroyImmediate(DetailRoot.GetChild(0).gameObject);
        }

        var itemList = tag.itemList;
        var otherSprite = PortraitHolder.instance.getPortrait(tag.chatName);
        var meSprite = PortraitHolder.instance.getPortrait("me");
        this.chatTarget = tag.chatTarget;
        
        foreach (var item in itemList)
        {
            GameObject go;
            if (item.isMe)
            {
                go = GameObject.Instantiate(MeChatItemPrefab);
            }
            else
            {
                go = GameObject.Instantiate(OtherChatItemPrefab);
            }
            
            go.transform.SetParent(DetailRoot);

            // init item
            var chatItem = go.GetComponent<OtherChatItem>();

            if (item.isMe)
            {
                chatItem.InitView(meSprite, item.content);
            }
            else
            {
                chatItem.InitView(otherSprite, item.content);
            }
        }

    }
}
