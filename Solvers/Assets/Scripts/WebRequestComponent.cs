using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using SOLVERS.DATA;
using Newtonsoft.Json;

public class WebRequestComponent : MonoBehaviour
{
    const string problemSheet = "https://script.google.com/macros/s/AKfycbzPXpaphzc3KKdhw5jP66BgSnmQtUW-BLvxKmRHXz4bcgEpnFIRoTIqH6QwyB4Nt6d8yg/exec";

    public enum DataType
    {
        User,
        ProblemStat
    }

    Dictionary<DataType, string> URL = new Dictionary<DataType, string>()
    {
        { DataType.User, "https://solved.ac/api/v3/user/show?handle=" },
        { DataType.ProblemStat, "https://solved.ac/api/v3/user/problem_stats?handle=" }
    };

    public void OnOrderRequested<T>(string userName, DataType type, Action<T> OnDataReceived, Action<string, string> OnErrorRequested)
    {
        StartCoroutine(DoOrderTask<T>(URL[type] + userName, OnDataReceived, OnErrorRequested));
    }

    public void OnOrderRequested(AppendSolvedDataOrder order, Action<string, string> OnErrorRequested)
    {
        StartCoroutine(DoOrderTask(order, OnErrorRequested));
    }

    public void OnOrderRequested<T>(ReadSheetOrder order, Action<T> OnDataReceived, Action<string, string> OnErrorRequested)
    {
        StartCoroutine(DoOrderTask<T>(order, OnDataReceived, OnErrorRequested));
    }

    public void OnOrderRequested(ContainRowOrder order, Action<string, bool> OnDataReceived, Action<string, string> OnErrorRequested)
    {
        StartCoroutine(DoOrderTask(order, OnDataReceived, OnErrorRequested));
    }

    public void OnOrderRequested(ModifySheetOrder order, Action<string> NextEventRequested, string eventValue, Action<string, string> OnLogReceived)
    {
        StartCoroutine(DoOrderTask(order, NextEventRequested, eventValue, OnLogReceived));
    }

    public void OnOrderRequested(ModifySheetOrder order, Action<string, string> OnLogReceived)
    {
        StartCoroutine(DoOrderTask(order, OnLogReceived));
    }

    WWWForm ReturnOrderForm(BaseOrder order)
    {
        string jsonData = JsonConvert.SerializeObject(order);
        WWWForm form = new WWWForm();
        form.AddField("json", jsonData);

        return form;
    }

    IEnumerator DoOrderTask<T>(string url, Action<T> OnDataReceived, Action<string, string> OnErrorRequested)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            if (www.isDone)
            {
                if (www.result == UnityWebRequest.Result.Success)
                {
                    T data = JsonConvert.DeserializeObject<T>(www.downloadHandler.text);
                    OnDataReceived?.Invoke(data);
                }
                else OnErrorRequested?.Invoke(www.result.ToString(), www.downloadHandler.text);
            }
        }
    }

    IEnumerator DoOrderTask(AppendSolvedDataOrder order, Action<string, string> OnErrorRequested)
    {
        WWWForm form = ReturnOrderForm(order);

        using (UnityWebRequest www = UnityWebRequest.Post(problemSheet, form))
        {
            yield return www.SendWebRequest();
            if (www.isDone)
            {
                if (www.result != UnityWebRequest.Result.Success)
                {
                    OnErrorRequested?.Invoke(www.result.ToString(), www.downloadHandler.text);
                }
            }
        }
    }

    IEnumerator DoOrderTask<T>(ReadSheetOrder order, Action<T> OnDataReceived, Action<string, string> OnErrorRequested)
    {
        WWWForm form = ReturnOrderForm(order);

        using (UnityWebRequest www = UnityWebRequest.Post(problemSheet, form))
        {
            yield return www.SendWebRequest();
            if (www.isDone)
            {
                if (www.result == UnityWebRequest.Result.Success)
                {
                    string jsonData = www.downloadHandler.text;
                    T data = JsonConvert.DeserializeObject<T>(jsonData);
                    OnDataReceived?.Invoke(data);
                }
                else OnErrorRequested?.Invoke(www.result.ToString(), www.downloadHandler.text);
            }

        }
    }

    IEnumerator DoOrderTask(ContainRowOrder order, Action<string, bool> OnDataReceived, Action<string, string> OnErrorRequested)
    {
        WWWForm form = ReturnOrderForm(order);

        using (UnityWebRequest www = UnityWebRequest.Post(problemSheet, form))
        {
            yield return www.SendWebRequest();
            if (www.isDone)
            {
                if (www.result == UnityWebRequest.Result.Success) OnDataReceived?.Invoke(order.value, Convert.ToBoolean(www.downloadHandler.text));
                else OnErrorRequested?.Invoke(www.result.ToString(), www.downloadHandler.text);
            }

        }
    }

    IEnumerator DoOrderTask(ModifySheetOrder order, Action<string> NextEventRequested, string value, Action<string, string> OnLogReceived)
    {
        WWWForm form = ReturnOrderForm(order);

        using (UnityWebRequest www = UnityWebRequest.Post(problemSheet, form))
        {
            yield return www.SendWebRequest();
            if (www.isDone)
            {
                NextEventRequested?.Invoke(value);
                OnLogReceived?.Invoke(www.result.ToString(), www.downloadHandler.text);
            }
        }
    }

    IEnumerator DoOrderTask(ModifySheetOrder order, Action<string, string> OnLogReceived)
    {
        WWWForm form = ReturnOrderForm(order);

        using (UnityWebRequest www = UnityWebRequest.Post(problemSheet, form))
        {
            yield return www.SendWebRequest();
            if(www.isDone)
            {
                OnLogReceived?.Invoke(www.result.ToString(), www.downloadHandler.text);
            }
        }
    }
}