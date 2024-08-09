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

    public void UpdateViewer(DateData data)
    {
        if (data.DateTime.DayOfWeek == DayOfWeek.Sunday) _dateTxt.color = _sundayColor;
        else if (data.DateTime.DayOfWeek == DayOfWeek.Saturday) _dateTxt.color = _saturdayColor;

        if (data.Month != data.DateTime.Month) _dateTxt.color = new Color(_dateTxt.color.r, _dateTxt.color.g, _dateTxt.color.b, _notSameMonthRatio);
        else _dateTxt.color = new Color(_dateTxt.color.r, _dateTxt.color.g, _dateTxt.color.b, 1f);

        if (data.DateTime == DateTime.Today) _background.color = _todayBackgroundColor;
        else _background.color = Color.black;

        _dateTxt.text = data.DateTime.Day.ToString();
        _solvedProblemTxt.text = data.ProblemNum;
    }
}
