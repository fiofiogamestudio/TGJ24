using System.Collections;
using System.Collections.Generic;
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

    }
}

public class MessageWrapper
{
    MessageInfo[] infos;
}

[System.Serializable]
public class MessageInfo
{
    public string number;
    public string day;
    public string dayOfWeek; // 星期几
    public string timeOfDay; // 几分几秒
    public int previewType; // 预览方式（配置省的计算） 0 日期 1 星期几 2 时间
    public string content; 
}
