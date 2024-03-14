using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calendar : MonoBehaviour
{
    [SerializeField] Transform _dateParent;
    [SerializeField] Date _datePrefab;
    [SerializeField] TMP_Text _monthTxt;

    [SerializeField] int _year;
    [SerializeField] int _month;
    [SerializeField] int _date;

    List<Date> _dates = new List<Date>();

    const int _rowCount = 5;
    const int _columnCount = 7;

    int[] dayOfMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    int GetBeforeMonth(int month) 
    {
        if (month == 1) return 12;
        else return month - 1;
    }

    public enum Day
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    private void Start()
    {
        //_month = int.Parse(System.DateTime.Now.ToString("MM"));
        //_date = int.Parse(System.DateTime.Now.ToString("dd"));

        _monthTxt.text = _month.ToString();
        Initialize();
    }

    int GetDayOfMonth(int year, int month)
    {
        dayOfMonth[1] += IsLeafYear(year);
        return dayOfMonth[month - 1];
    }

    int GetDay(int year, int month)
    {
        int past = 0;
        for (int i = 1; i < year; i++) past = past + 365 + IsLeafYear(i);
        for (int j = 1; j < month; j++) past = past + GetDayOfMonth(year, j);
        return past % 7;
    }

    int IsLeafYear(int year)
    {
        if (year % 400 == 0) return 1;
        if ((year % 100 != 0) && (year % 4 == 0)) return 1;
        return 0;
    }

    public void Initialize()
    {
        //int beforeMonth = GetBeforeMonth(_month);
        //dayOfMonth[beforeMonth - 1];
        int startNum1 = 1;

        int startNum = GetDay(_year, _month);
        Debug.Log(startNum);

        int count = _rowCount * _columnCount;
        for (int i = 1; i <= count; i++)
        {
            Date date = Instantiate(_datePrefab, _dateParent);
            if(i > startNum && startNum1 <= dayOfMonth[_month - 1])
            {
                date.ResetTxt(startNum1);
                startNum1++;
            }

            _dates.Add(date);
        }
    }
}
