using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppCalendar : AppBase
{
    protected override void Awake()
    {
        base.Awake();
    }

    #region UI相关变量定义
    [SerializeField]
    GameObject body;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // 获取所有需要控制的Day
        AppCalendarDay[] days = body.GetComponentsInChildren<AppCalendarDay>();
        foreach (AppCalendarDay day in days)
        {
            day.SetDayText("1");
            day.SetTodayMark(false);
            day.SetEventMark(false);
        }
    }
}
