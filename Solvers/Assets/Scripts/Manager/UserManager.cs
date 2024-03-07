using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOLVERS.DATA;
using SOLVERS.RECEIVER;
using System;
using UnityEngine.SceneManagement;

namespace SOLVERS.MANAGER
{
    // ΩÃ±€≈Ê¿∏∑Œ ∏∏µÈ±‚
    public class UserManager : Singleton<UserManager>
    {
        WebRequestReceiver _webRequestReceiver;
        JsonParser _jsonParser;

        [SerializeField] UserData _userData;
        public UserData UserData { get { return _userData; } }

        // Start is called before the first frame update
        void Start()
        {
            _webRequestReceiver = GetComponent<WebRequestReceiver>();
            _jsonParser = GetComponent<JsonParser>();
        }

        public static void ClearLoginData()
        {
            _instance._userData = null;
        }

        public static void Login(string userName)
        {
            _instance._webRequestReceiver.OnWebDataRequested(userName, WebRequestReceiver.Type.User, _instance.OnUserDataRequested);
            //_instance._webRequestReceiver.OnWebDataRequested(userName, WebRequestReceiver.Type.ProblemStat, _instance.OnProblemStatRequested);
            //_instance._webRequestReceiver.OnWebDataRequested(userName, WebRequestReceiver.Type.Top100, _instance.OnTop100Requested);
        }

        void OnUserDataRequested(string json)
        {
            _userData = _jsonParser.ConvertJsonToData<UserData>(json);
            SceneManager.LoadScene("SelectScene");
        }

        void OnProblemStatRequested(string json)
        {
            _userData = _jsonParser.ConvertJsonToData<UserData>(json);
            SceneManager.LoadScene("SelectScene");
        }

        void OnTop100Requested(string json)
        {
            _userData = _jsonParser.ConvertJsonToData<UserData>(json);
            SceneManager.LoadScene("SelectScene");
        }
    }
}