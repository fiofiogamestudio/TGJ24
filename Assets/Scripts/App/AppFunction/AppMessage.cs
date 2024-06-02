using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppMessage : AppBase
{
    public GameObject MessagePrefab;
    public Transform MessageRoot;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();

        generateMessages();
    }

    void generateMessages()
    {
        foreach (var id in DataHolder.instance.initMessageList)
        {
            var go = GameObject.Instantiate(MessagePrefab);
            go.transform.SetParent(MessageRoot);

            // 初始化 Message Item

            var item = go.GetComponent<MessageItem>();
            item.Init(MessageHolder.instance.GetMessage(id), this);
        }
    }


    [ReadOnly]
    public MessageItem selectedItem = null;

    public void SelectItem(MessageItem item)
    {
        selectedItem = item;
        if (selectedItem != null)
        {

        }
    }

    public void ShowOrHideDetailMessage(bool showOrHide)
    {
        
    }
}
