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

    public Scrollbar bar;


    public void RefreshDetail(ChatTag tag)
    {
        DetailName.text = tag.chatName;

        while (DetailRoot.childCount != 0)
        {
            GameObject.DestroyImmediate(DetailRoot.GetChild(0).gameObject);
        }

        var itemList = tag.itemList;
        var otherSprite = PortraitHolder.instance.GetPortrait(tag.chatName);
        var meSprite = PortraitHolder.instance.GetPortrait("me");
        this.chatTarget = tag.chatTarget;
        
        foreach (var item in itemList)
        {
            if (!item.show) continue;

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
                chatItem.InitView(meSprite, item.content, item.time);
            }
            else
            {
                chatItem.InitView(otherSprite, item.content, item.time);
            }
        }

        StartCoroutine(IEForceBar());
    }

    IEnumerator IEForceBar(float time = 0.5f)
    {
        for (float timer = 0f; timer < time; timer += 0.02f)
        {
            yield return new WaitForSeconds(0.02f);
            bar.value = 0;
        }
    }
}
