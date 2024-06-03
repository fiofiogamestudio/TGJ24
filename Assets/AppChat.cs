using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AppChat : AppBase
{
    public static AppChat instance;
    public GameObject ChatPrefab;
    public Transform ChatRoot;

    public Button BackButton;

    public ChatDetailPanel DetailPanel;

    protected override void Awake()
    {
        base.Awake();
        if (instance == null) instance = this;

        BackButton.onClick.AddListener(()=>{ShowOrHideDetail(false);});
    }

    protected override void Start()
    {
        base.Start();

        InitChatToken();
    }

    public override void Close()
    {
        base.Close();
        ShowOrHideDetail(false);
    }

    public Image newTip;
    public void TipNew(string tagName)
    {
        int count = ChatRoot.childCount;
        for (int i = 0; i < count; i++)
        {
            var tag = ChatRoot.GetChild(i).GetComponent<ChatTag>();
            if (tag.chatName == tagName)
                tag.TipNew();
        }
        // newTip.gameObject.SetActive(true);
    }

    public override void Open()
    {
        base.Open();
        newTip.gameObject.SetActive(false);
    }

    public void InitChatToken()
    {
        while (ChatRoot.childCount != 0)
        {
            GameObject.DestroyImmediate(ChatRoot.GetChild(0));
        }

        foreach (var chatRecord in ChatHolder.instance.ChatRecordList)
        {
            var go = GameObject.Instantiate(ChatPrefab);
            go.transform.SetParent(ChatRoot);

            // 初始化 Chat Tag

            var tag = go.GetComponent<ChatTag>();
            tag.Init(chatRecord, this);
        }
    }

    public void RefreshChat()
    {
        // refresh chat tag
        for (int i = 0; i < ChatRoot.childCount; i++)
        {
            var tag = ChatRoot.GetChild(i).GetComponent<ChatTag>();
            tag.Reload();
        }

        // refresh chat detail
        if (selectedChat != null)
            DetailPanel.RefreshDetail(selectedChat);
    }



    [ReadOnly]
    public ChatTag selectedChat;

    public void SelectChat(ChatTag tag)
    {
        selectedChat = tag;
        if (selectedChat != null)
        {
            ShowOrHideDetail(true);
        }
    }

    [ReadOnly]
    public bool isOpeningDetail = false;

    void ShowOrHideDetail(bool showOrHide)
    {
        if (isOpeningDetail) return;
        if (showOrHide)
        {
            // show detail
            DetailPanel.RefreshDetail(selectedChat);
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
