using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppMessage : AppBase
{
    public GameObject MessagePrefab;
    public Transform MessageRoot;

    public MessageDetailPanel DetailPanel;

    public Button BackButton;
    
    protected override void Awake()
    {
        base.Awake();

        BackButton.onClick.AddListener(()=>{ShowOrHideDetail(false);});
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
            // 通用
            ShowOrHideDetail(true);
        }
    }

    void ShowOrHideDetail(bool showOrHide)
    {
        if (isOpeningDetail) return;
        if (showOrHide)
        {
            // show detail
            DetailPanel.RefreshDetail(selectedItem.number);
            // show
            StartCoroutine(
                IEShowOrHideChatDetail(500, 0)
            );

        }
        else
        {
            DetailPanel.ClearDetail();
            StartCoroutine(
                IEShowOrHideChatDetail(0, 500)
            );

        }
    }

    [ReadOnly]
    public bool isOpeningDetail = false;
    IEnumerator IEShowOrHideChatDetail(float startX, float endX, float openTime = 0.15f)
    {
        isOpeningDetail = true;

        RectTransform detailRect = DetailPanel.GetComponent<RectTransform>();
        Vector3 pos = detailRect.localPosition;
        Vector3 startPos = new Vector3(startX, pos.y, pos.z);
        Vector3 endPos = new Vector3(endX, pos.y, pos.z);


        for (float time = 0; time < openTime; time += 0.02f)
        {
            float t = time / openTime;
            
            detailRect.localPosition = Vector3.Lerp(startPos, endPos, t);

            yield return new WaitForSeconds(0.02f);
        }

        detailRect.localPosition = endPos;

        isOpeningDetail = false;
    }
}
