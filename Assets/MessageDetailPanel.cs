using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageDetailPanel : MonoBehaviour
{
    public Text DetailNumber;

    public GameObject MessageItemPrefab;

    public Transform DetailRoot;

    void Awake() {}

    public void ClearDetail()
    {
        while (DetailRoot.childCount != 0)
        {
            GameObject.DestroyImmediate(DetailRoot.GetChild(0).gameObject);
        }
    }

    public void RefreshDetail(string number)
    {
        DetailNumber.text = number;

        ClearDetail();

        var messageList = MessageHolder.instance.GetAllMessage(number);

        foreach (var message in messageList)
        {
            GameObject go = GameObject.Instantiate(MessageItemPrefab);

            go.transform.SetParent(DetailRoot);

            // init item
            var defaultSprite = PortraitHolder.instance.GetPortrait("default");

            var chatItem = go.GetComponent<OtherChatItem>();

            chatItem.InitView(defaultSprite, message.content, message.day);
        }
    }
}
