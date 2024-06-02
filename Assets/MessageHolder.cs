using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageHolder : MonoBehaviour
{
    public static MessageHolder instance;
    void Awake()
    {
        if (instance == null) instance = this;
        
        loadMessages();
    }

    [ReadOnly]
    public List<MessageInfo> messageList = new List<MessageInfo>();

    void loadMessages()
    {
        MessageWrapper messageWrapper = DataLoader.LoadJson<MessageWrapper>(PathConfig.MESSAGE_PATH);
        MessageInfo[] messages = messageWrapper.infos;
        messageList.Clear();
        messageList.AddRange(messages);
    }

    public MessageInfo GetMessage(int id)
    {
        foreach (var message in messageList)
        {
            if (message.id == id) return message;
        }
        return null;
    }
}

public class MessageWrapper
{
    public MessageInfo[] infos;
}

[System.Serializable]
public class MessageInfo
{
    public int id;
    public string number;
    public string day;
    public string dayOfWeek; // 星期几
    public string timeOfDay; // 几分几秒
    public int previewType; // 预览方式（配置省的计算） 0 日期 1 星期几 2 时间 3 昨天
    public string content; 
    public string clueToken; // 线索的标签
}
