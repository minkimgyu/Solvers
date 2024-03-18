using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOLVERS.DATA;
using System;
using SOLVERS.Controller;

namespace SOLVERS.Manager
{
    // ΩÃ±€≈Ê¿∏∑Œ ∏∏µÈ±‚
    public class UserManager : Singleton<UserManager>
    {
        [SerializeField] UserData _userData;
        public UserData UserData { get { return _userData; } set { _userData = value; } }

        [SerializeField] string _registerDate;
        public string RegisterDate { get { return _registerDate; } set { _registerDate = value; } }

        [SerializeField] List<ProblemData> _problemDatas;
        public List<ProblemData> ProblemDatas { get { return _problemDatas; } set { _problemDatas = value; } }

        RequestController _requestController;

        // Start is called before the first frame update
        void Start()
        {
            _requestController = GetComponent<RequestController>();
            _requestController.Initialize();
        }

        public static void ClearLoginData()
        {
            _instance._userData = null;
            _instance._registerDate = null;
            _instance._problemDatas = null;
        }

        public static void Login(string userName)
        {
            _instance._requestController.OnLogin(userName);
        }

        public static void Register(string userName)
        {
            _instance._requestController.OnRegister(userName);
        }
    }
}