using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppCalendarDay : MonoBehaviour
{
    #region UI相关变量定义
    [SerializeField]
    Text DayText;
    [SerializeField]
    GameObject TodayMark;
    [SerializeField]
    GameObject EventMark;
    #endregion

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
}
