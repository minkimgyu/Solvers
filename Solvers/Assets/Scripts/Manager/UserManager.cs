using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOLVERS.DATA;
using SOLVERS.RECEIVER;
using System;
using UnityEngine.SceneManagement;

namespace SOLVERS.Manager
{
    // �̱������� �����
    public class UserManager : Singleton<UserManager>
    {
        WebRequestManager _webRequestManager;
        [SerializeField] Transform _popUpParent;

        [SerializeField] PopUp _popUpPrefab;

        [SerializeField] UserData _userData;
        public UserData UserData { get { return _userData; } }

        [SerializeField] string _registerDate;
        public string RegisterDate { get { return _registerDate; } }

        [SerializeField] List<ProblemData> _problemDatas;
        public List<ProblemData> ProblemDatas { get { return _problemDatas; } }

        // Start is called before the first frame update
        void Start()
        {
            _webRequestManager = GetComponent<WebRequestManager>();
        }

        public static void ClearLoginData()
        {
            _instance._userData = null;
            _instance._registerDate = null;
            _instance._problemDatas = null;
        }

        void FindUserName(string userName, Action<string, bool> OnDataReceived)
        {
            ContainRowOrder order = new ContainRowOrder("Register", "userName", userName);
            _instance._webRequestManager.OnOrderRequested(order, OnDataReceived, _instance.OnLogRequested);
        }

        void OnLogRequested(string result, string log)
        {
            PopUp popUp = Instantiate(_popUpPrefab, _popUpParent);
            popUp.Initialize(result, log);
        }

        #region Login

        public static void Login(string userName)
        {
            _instance.FindUserName(userName, _instance.TryLogin);
        }

        void TryLogin(string userName, bool isAlreadyRegistered)
        {
            if (isAlreadyRegistered == false)
            {
                _instance.OnLogRequested("�α��� ����", "��ϵ��� ���� �����Դϴ�.");
            }
            else
            {
                _instance._webRequestManager.OnOrderRequested<UserData>
                (userName, WebRequestManager.DataType.User, _instance.OnLoginRequested, _instance.OnLogRequested);
            }
        }

        void OnLoginRequested(UserData data)
        {
            _userData = data;
            ReadSheetOrder order = new ReadSheetOrder("SolvedProblem_" + data.handle);
            _instance._webRequestManager.OnOrderRequested<List<ProblemData>>(order, OnSolvedDataReceived, _instance.OnLogRequested);
        }

        void OnSolvedDataReceived(List<ProblemData> datas)
        {
            // �̶� ��Ʈ���� Ǭ ������ ���� ���� �޾ƿ���
            _problemDatas = datas;
            ReadSheetOrder order = new ReadSheetOrder("Register");
            _instance._webRequestManager.OnOrderRequested<List<RegisterData>>(order, OnRegisterDataReceived, _instance.OnLogRequested);
        }

        void OnRegisterDataReceived(List<RegisterData> registerData)
        {
            // ȸ�� ������ ��¥�� �޾ƿ���
            RegisterData data = registerData.Find(x => x.userName == _userData.handle);
            _registerDate = data.registerDate;

            SceneManager.LoadScene("SelectScene");
        }

        #endregion

        #region Register

        public static void Register(string userName) => _instance.FindUserName(userName, _instance.TryRegister);

        void TryRegister(string userName, bool isAlreadyRegistered)
        {
            if (isAlreadyRegistered == true)
            {
                _instance.OnLogRequested("��� ����", "�̹� ��ϵ� �����Դϴ�.");
                return;
            }
            else
            {
                _instance._webRequestManager.OnOrderRequested<UserData>
                    (userName, WebRequestManager.DataType.User, _instance.OnRegisterRequested, _instance.OnLogRequested);
            }
        }

        string ConvertDateTimeToString(DateTime dateTime) { return dateTime.ToString("yyyy.MM.dd"); }

        void OnRegisterRequested(UserData data)
        {
            string date = ConvertDateTimeToString(DateTime.Now);
            RegisterData registerData = new RegisterData(data.handle, date);

            ModifySheetOrder order = new InsertRowOrder<RegisterData>("Register", registerData);
            _instance._webRequestManager.OnOrderRequested(order, AddSolvedDataRequested, data.handle, _instance.OnLogRequested);
        }

        void AddSolvedDataRequested(string userName)
        {
            AppendSolvedDataOrder order = new AppendSolvedDataOrder(userName);
            _instance._webRequestManager.OnOrderRequested(order, _instance.OnLogRequested);
        }

      

        #endregion
    }
}