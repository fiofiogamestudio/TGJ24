using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class ChatHolder : MonoBehaviour
{
    public static ChatHolder instance;

    void Awake()
    {
        if (instance == null) instance = this;

        loadChats();
    }

    [ReadOnly]
    public List<ChatRecord> ChatRecordList = new List<ChatRecord>();

    void loadChats()
    {
        ChatWrapper chatWrapper = DataLoader.LoadJson<ChatWrapper>(PathConfig.CHAT_PATH);
        ChatInfo[] chats = chatWrapper.infos;
        ChatRecordList.Clear();
        foreach (var chat in chats)
        {
            ChatRecordList.Add(
                new ChatRecord(chat.name, chat.items, chat.chatTarget)
            );
        }
    }
}

[System.Serializable]
public class ChatRecord
{
    public string name;
    public List<ChatItemInfo> itemList = new List<ChatItemInfo>();
    public int chatTarget = 0;
    public ChatRecord(string name, ChatItemInfo[] items, int chatTarget)
    {
        this.name = name;
        this.itemList.AddRange(items);
        this.chatTarget = chatTarget;
    }
}

[System.Serializable]
public class ChatWrapper
{
    public ChatInfo[] infos;
}

[System.Serializable]
public class ChatInfo
{
    public string name;
    public ChatItemInfo[] items;
    public int chatTarget; // 如果触发对话，目标对话索引  2001 表示没有什么可说的
}

[System.Serializable]
public class ChatItemInfo
{
    public int id; // id (顺序)
    public bool show; // 是否显示
    public bool isMe; // true: 我发送的 false: 对面发送的
    public string time; // 发送时间 格式 yyyy/mm/dd hh:mm
    public string content;
}
