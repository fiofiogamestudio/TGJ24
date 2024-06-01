using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AppCalendar : AppBase
{
    protected override void Awake()
    {
        base.Awake();
    }

    #region UI相关变量定义
    [SerializeField]
    GameObject body;
    List<List<AppCalendarDay>> days;
    [SerializeField]
    GameObject detail;
    [SerializeField]
    Text detailTitle;
    [SerializeField]
    Text detailContent;
    #endregion

    #region 数据相关变量
    int year = 2024;
    int month = 6;
    int day = 1;

    // 事件数据
    List<int> eventMonth = new List<int>();
    List<int> eventDay = new List<int>();
    List<String> eventContent = new List<String>();
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // 获取所有需要控制的Day
        days = new List<List<AppCalendarDay>>();
        foreach (Transform child in body.transform)
        {
            List<AppCalendarDay> dayList = new List<AppCalendarDay>();
            foreach (Transform day in child)
            {
                AppCalendarDay appCalendarDay = day.GetComponent<AppCalendarDay>();
                dayList.Add(appCalendarDay);
                appCalendarDay.SetRoot(this);
            }
            days.Add(dayList);
        }

        // 初始化事件数据
        eventMonth.Add(6);
        eventDay.Add(1);
        eventContent.Add("儿童节");
        eventMonth.Add(6);
        eventDay.Add(3);
        eventContent.Add("TGJ提交");
        eventMonth.Add(7);
        eventDay.Add(12);
        eventContent.Add("放暑假");

        Refresh();
    }

    #region UI控制函数
    public void ShowDetail(int month, int day)
    {
        detail.SetActive(true);
        detailTitle.text = month + "月" + day + "日";
        detailContent.text = "这是" + month + "月" + day + "日的内容";
        for (int i = 0; i < eventMonth.Count; i++)
        {
            if (eventMonth[i] == month && eventDay[i] == day)
            {
                detailContent.text = eventContent[i];
                break;
            }
            else
            {
                detailContent.text = "今日无事发生";
            }
        }
    }

    void ClearRow(int row)
    {
        foreach (var day in days[row])
        {
            day.SetDayText("");
            day.SetTodayMark(false);
            day.SetEventMark(false);
        }
    }

    void ClearAll()
    {
        for (int i = 0; i < days.Count; i++)
        {
            ClearRow(i);
        }
    }

    void SetDay(int row, int col, String text, bool isToday, bool hasEvent, int month, int day)
    {
        days[row][col].SetDayText(text);
        days[row][col].SetTodayMark(isToday);
        days[row][col].SetEventMark(hasEvent);
        days[row][col].SetData(month, day);
    }

    void SetDayEvent(int row, int col)
    {
        days[row][col].SetEventMark(true);
    }
    #endregion

    void Refresh()
    {
        // 初始化
        ClearAll();

        // 设置基本日历
        ShowBasicCalendar();

        // 高亮今日
        ShowToday();

        // 设置事件
        ShowEvent();
    }

    private void ShowEvent()
    {
        for (int i = 0; i < eventMonth.Count; i++)
        {
            int monthOfEvent = eventMonth[i];
            int dayOfEvent = eventDay[i];

            if (monthOfEvent == month)
            {
                int index = dayOfEvent + GetWeekday(year, monthOfEvent, 1) - 1;
                int row = index / 7 + 1;
                int col = index % 7;
                SetDayEvent(row, col);
            }
            else if (monthOfEvent == month + 1)
            {
                int index = dayOfEvent + GetWeekday(year, monthOfEvent, 1) - 1;
                int row = index / 7 + 7;
                int col = index % 7;
                SetDayEvent(row, col);
            }
        }
    }

    private void ShowToday()
    {
        int weekday = GetWeekday(year, month, day);
        int row = (weekday + day - 1) / 7 + 1;
        int col = (weekday + day - 1) % 7;
        SetDay(row, col, day.ToString(), true, false, month, day);
    }

    private void ShowBasicCalendar()
    {
        // 根据日期获取星期
        int weekday = GetWeekday(year, month, day);

        // 设置当月月份
        SetDay(0, weekday, month + "月", false, false, 0, 0);

        // 设置当月日期
        int daysInMonth = DateTime.DaysInMonth(year, month);
        for (int i = 1; i <= daysInMonth; i++)
        {
            int index = weekday + i - 1;
            int row = index / 7 + 1;
            int col = index % 7;
            SetDay(row, col, i.ToString(), false, false, month, i);
        }

        // 设置下月日期
        int nextMonth = month + 1;
        int nextYear = year;
        if (nextMonth > 12)
        {
            nextMonth = 1;
            nextYear++;

        }

        int weekdayNextMonth = GetWeekday(nextYear, nextMonth, 1);
        // 设置下个月月份
        SetDay(6, weekdayNextMonth, nextMonth + "月", false, false, 0, 0);

        int nextMonthDays = DateTime.DaysInMonth(nextYear, nextMonth);
        for (int i = 1; i <= nextMonthDays; i++)
        {
            int index = weekdayNextMonth + i - 1;
            int row = index / 7 + 7;
            int col = index % 7;
            SetDay(row, col, i.ToString(), false, false, nextMonth, i);
        }
    }

    // return 0-6, 0 is Monday, 6 is Sunday
    private int GetWeekday(int year, int month, int day)
    {
        if (month == 1 || month == 2)
        {
            month += 12;
            year--;
        }
        int c = year / 100;
        year = year % 100;
        int w = year + year / 4 + c / 4 - 2 * c + 26 * (month + 1) / 10 + day - 1;
        w = (w % 7 + 7) % 7;
        if (w == 0)
        {
            w = 6;
        }
        else
        {
            w--;
        }
        return w;
    }
}
