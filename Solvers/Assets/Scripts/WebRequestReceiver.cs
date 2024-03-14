using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using SOLVERS.DATA;
using Newtonsoft.Json;

namespace SOLVERS.RECEIVER
{

    public class WebRequestReceiver : MonoBehaviour
    {
        public enum Type
        {
            User,
            ProblemStat,
            Top100,
            GoogleSheetTest,
        }

        Dictionary<Type, string> URL = new Dictionary<Type, string>()
        {
            { Type.User, "https://solved.ac/api/v3/user/show?handle=" },
            { Type.ProblemStat, "https://solved.ac/api/v3/user/problem_stats?handle=" },
            { Type.Top100, "https://solved.ac/api/v3/user/top_100?handle=" },

            { Type.GoogleSheetTest, "https://script.google.com/macros/s/AKfycbwlKLySZ1SvHzJFQ_G4ThurmRw05E3BudDhDysSHWloSya-VQlb4LLj4PuRuTyR0EZYnw/exec" }
        };



        //IEnumerator Start()
        //{
        //    BaseOrder order = new InsertRowOrder(13, "bdd", "meal1431", "https://www.youtube.com/watch?v=84kUgP1dW2E", "test");
        //    BaseOrder order = new DeleteRowOrder("TITLE", "bdd");
        //    BaseOrder order = new ChangeRowOrder("INDEX", "15", "1123");
        //    string jsonData = JsonUtility.ToJson(order);

        //    WWWForm form = new WWWForm();
        //    form.AddField("json", jsonData);

        //    using (UnityWebRequest www = UnityWebRequest.Post(URL[Type.GoogleSheetTest], form))
        //    {
        //        yield return www.SendWebRequest();

        //        if (www.isDone)
        //        {
        //            string json = www.downloadHandler.text;
        //            print(json);
        //        }
        //        else
        //        {
        //            print("에러");
        //        }
        //    }
        //}

        IEnumerator Start()
        {
            //BaseOrder order = new InsertRowOrder("Calendar", 13, "bdd", "meal1431", "https://www.youtube.com/watch?v=84kUgP1dW2E", "test");
            //BaseOrder order = new DeleteRowOrder("Calendar", "TITLE", "1123678678");
            BaseOrder order = new ChangeRowOrder("Calendar", "TITLE", "bdd", "1123");
            string jsonData = JsonUtility.ToJson(order);

            WWWForm form = new WWWForm();
            form.AddField("json", jsonData);

            using (UnityWebRequest www = UnityWebRequest.Post(URL[Type.GoogleSheetTest], form))
            {
                yield return www.SendWebRequest();

                if (www.isDone)
                {
                    string json = www.downloadHandler.text;
                    print(json);
                }
                else
                {
                    print("에러");
                }
            }
        }

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