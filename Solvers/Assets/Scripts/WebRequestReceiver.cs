using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using SOLVERS.MANAGER;

namespace SOLVERS.RECEIVER
{

    public class WebRequestReceiver : MonoBehaviour
    {
        public enum Type
        {
            User,
            ProblemStat,
            Top100,
        }

        Dictionary<Type, string> URL = new Dictionary<Type, string>()
        {
            { Type.User, "https://solved.ac/api/v3/user/show?handle=" },
            { Type.ProblemStat, "https://solved.ac/api/v3/user/problem_stats?handle=" },
            { Type.Top100, "https://solved.ac/api/v3/user/top_100?handle=" }
        };

        //IEnumerator Start()
        //{
        //    UnityWebRequest www = UnityWebRequest.Get(URL[Type.Top100] + "realm_eal");
        //    yield return www.SendWebRequest();

        //    string json = www.downloadHandler.text;
        //    print(json);
        //}

        public void OnWebDataRequested(string userName, Type type, Action<string> onDataReceived)
        {
            StartCoroutine(ReceiveData(userName, type, onDataReceived));
        }

        // Start is called before the first frame update
        IEnumerator ReceiveData(string userName, Type type, Action<string> onDataReceived)
        {
            UnityWebRequest www = UnityWebRequest.Get(URL[type] + userName);
            yield return www.SendWebRequest();

            string json = www.downloadHandler.text;
            print(json);
            onDataReceived?.Invoke(json);
        }
    }
}