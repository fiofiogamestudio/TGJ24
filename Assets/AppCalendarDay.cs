using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppCalendarDay : MonoBehaviour
{
    AppCalendar root;

    #region UI相关变量定义
    [SerializeField]
    Text DayText;
    [SerializeField]
    GameObject TodayMark;
    [SerializeField]
    GameObject EventMark;
    #endregion

    public void SetRoot(AppCalendar root)
    {
        this.root = root;
    }

    #region UI控制函数
    public void SetDayText(int day)
    {
        DayText.text = day.ToString();
    }
    public void SetDayText(string text)
    {
        DayText.text = text;
    }
    public void SetTodayMark(bool isToday)
    {
        TodayMark.SetActive(isToday);
    }

    public void SetEventMark(bool hasEvent)
    {
        EventMark.SetActive(hasEvent);
    }
    #endregion

    #region 数据存储
    int month = 0;
    int day = 0;

    public void SetData(int month, int day)
    {
        this.month = month;
        this.day = day;
    }
    #endregion

    public void OnClick()
    {
        root.ShowDetail(month, day);
    }
}
