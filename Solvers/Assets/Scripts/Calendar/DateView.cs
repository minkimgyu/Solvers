using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DateView : MonoBehaviour
{
    [SerializeField] TMP_Text _dateTxt;
    [SerializeField] TMP_Text _solvedProblemTxt;

    [SerializeField] Image _background;

    [SerializeField] Color _sundayColor;
    [SerializeField] Color _saturdayColor;
    [SerializeField] Color _todayBackgroundColor;

    [SerializeField] float _notSameMonthRatio = 0.1f;

    public void SetDate(int month, DateTime dateTime)
    {
        if (dateTime.DayOfWeek == DayOfWeek.Sunday) _dateTxt.color = _sundayColor;
        else if (dateTime.DayOfWeek == DayOfWeek.Saturday) _dateTxt.color = _saturdayColor;

        if (month != dateTime.Month) _dateTxt.color = new Color(_dateTxt.color.r, _dateTxt.color.g, _dateTxt.color.b, _notSameMonthRatio);
        else _dateTxt.color = new Color(_dateTxt.color.r, _dateTxt.color.g, _dateTxt.color.b, 1f);

        if (dateTime == DateTime.Today) _background.color = _todayBackgroundColor;
        else _background.color = Color.black;

        _dateTxt.text = dateTime.Day.ToString();
    }

    public void SetSolvedProblem(string problemNum)
    {
        _solvedProblemTxt.text = problemNum;
    }
}
