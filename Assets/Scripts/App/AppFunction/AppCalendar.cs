using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    List<List<AppCalendarDay>> days;
    #endregion

    #region 数据相关变量
    int year = 2024;
    int month = 6;
    int day = 1;
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
                dayList.Add(day.GetComponent<AppCalendarDay>());
            }
            days.Add(dayList);
        }
        Refresh();
    }

    #region UI控制函数
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

    void SetDay(int row, int col, String day, bool isToday, bool hasEvent)
    {
        days[row][col].SetDayText(day);
        days[row][col].SetTodayMark(isToday);
        days[row][col].SetEventMark(hasEvent);
    }
    #endregion

    void Refresh()
    {
        // 初始化
        ClearAll();

        // 设置基本日历
        SetBasicCalendar();

        // 高亮今日
        SetToday();
    }

    private void SetToday()
    {
        int weekday = GetWeekday(year, month, day);
        int row = (weekday + day - 1) / 7 + 1;
        int col = (weekday + day - 1) % 7;
        SetDay(row, col, day.ToString(), true, false);
    }

    private void SetBasicCalendar()
    {
        // 根据日期获取星期
        int weekday = GetWeekday(year, month, day);

        // 设置当月月份
        SetDay(0, weekday, month + "月", false, false);

        // 设置当月日期
        int daysInMonth = DateTime.DaysInMonth(year, month);
        for (int i = 1; i <= daysInMonth; i++)
        {
            int index = weekday + i - 1;
            int row = index / 7 + 1;
            int col = index % 7;
            SetDay(row, col, i.ToString(), false, false);
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
        SetDay(6, weekdayNextMonth, nextMonth + "月", false, false);

        int nextMonthDays = DateTime.DaysInMonth(nextYear, nextMonth);
        for (int i = 1; i <= nextMonthDays; i++)
        {
            int index = weekdayNextMonth + i - 1;
            int row = index / 7 + 7;
            int col = index % 7;
            SetDay(row, col, i.ToString(), false, false);
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
