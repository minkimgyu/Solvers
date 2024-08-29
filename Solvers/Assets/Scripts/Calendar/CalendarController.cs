using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using SOLVERS.Manager;
using SOLVERS.DATA;

public class DateModel
{
    public DateModel(DateView view)
    {
        _view = view;
    }

    DateView _view;

    int _month;
    DateTime _dateTime;
    string _problemNum;

    public int Month 
    { 
        get => _month;
        set
        {
            _month = value;
        }
    }

    public DateTime DateTime
    {
        get => _dateTime;
        set
        {
            _dateTime = value;
            _view.SetDate(_month, _dateTime);
        }
    }

    public string ProblemNum
    {
        get => _problemNum;
        set
        {
            _problemNum = value;
            _view.SetSolvedProblem(_problemNum);
        }
    }
}

public class CalendarController : MonoBehaviour
{
    [SerializeField] Transform _dateParent;
    [SerializeField] DateView _datePrefab;

    [SerializeField] TMP_Text _yearTxt;
    [SerializeField] TMP_Text _monthTxt;

    [SerializeField] Button _leftBtn;
    [SerializeField] Button _RightBtn;

    [SerializeField] int _year;
    int Year { get { return _year; } set { _year = value; _yearTxt.text = _year.ToString(); } }

    [SerializeField] int _month;
    int Month { get { return _month; } set { _month = value; _monthTxt.text = _month.ToString(); } }

    List<DateView> _dates = new List<DateView>();
    List<DateModel> _models = new List<DateModel>();

    const int _rowCount = 5;
    const int _columnCount = 7;

    void ResetMonth(bool nowUp)
    {
        if (nowUp)
        {
            if (Month == 12)
            {
                Year += 1;
                Month = 1;
                return;
            }

            Month += 1;
        }
        else
        {
            if (Month == 1)
            {
                Year -= 1;
                Month = 12;
                return;
            }

            Month -= 1;
        }
    }

    private void Start()
    {
        Year = int.Parse(System.DateTime.Now.ToString("yyyy"));
        Month = int.Parse(System.DateTime.Now.ToString("MM"));

        _leftBtn.onClick.AddListener(() => { ResetMonth(false); ResetCalendar(); });
        _RightBtn.onClick.AddListener(() => { ResetMonth(true); ResetCalendar(); });

        Initialize();
    }

    DateTime ReturnMonthStartDate()
    {
        DateTime day = new DateTime(Year, Month, 1);
        int dayOfWeek = (int)day.DayOfWeek;
        return day.AddDays(-dayOfWeek); // 달력의 처음부터 시작함
    }

    DateTime ConvertStringToDateTime(string dateTime) { return DateTime.Parse(dateTime); }

    string ReturnProblemNumbers(DateTime startDateTime)
    {
        string problemNum = "";
        if(startDateTime == ConvertStringToDateTime(UserManager.Instance.RegisterDate)) return problemNum; // 등록 날짜와 같다면 리턴

        List<ProblemData> problemDatas = UserManager.Instance.ProblemDatas.FindAll(x => ConvertStringToDateTime(x.date) == startDateTime);
        for (int j = 0; j < problemDatas.Count; j++)
        {
            if (j == problemDatas.Count - 1) problemNum += problemDatas[j].problemId;
            else problemNum += problemDatas[j].problemId + ", ";
        }

        return problemNum;
    }

    void ResetCalendar()
    {
        DateTime startDateTime = ReturnMonthStartDate();
        for (int i = 0; i < _dates.Count; i++)
        {
            string problemNum = ReturnProblemNumbers(startDateTime);

            _models[i].Month = Month;
            _models[i].DateTime = startDateTime;
            _models[i].ProblemNum = problemNum;
            startDateTime = startDateTime.AddDays(1);
        }
    }

    public void Initialize()
    {
        int count = _rowCount * _columnCount;
        for (int i = 0; i < count; i++)
        {
            DateView date = Instantiate(_datePrefab, _dateParent);
            _dates.Add(date);
            _models.Add(new DateModel(date));
        }

        ResetCalendar();
    }
}
