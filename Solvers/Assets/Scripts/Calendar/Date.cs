using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Date : MonoBehaviour
{
    [SerializeField] TMP_Text _dateTxt;
    [SerializeField] TMP_Text _solvedProblemTxt;

    public void ResetTxt(int date)
    {
        _dateTxt.text = date.ToString();
        _solvedProblemTxt.text = "";
    }

    public void ResetTxt(int date, int problemNum)
    {
        _dateTxt.text = date.ToString();
        _solvedProblemTxt.text = problemNum.ToString();
    }
}
