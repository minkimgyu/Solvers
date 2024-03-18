using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOLVERS.DATA;
using SOLVERS.Manager;
using SOLVERS.Controller;

namespace SOLVERS.Fsm.RequestState
{
    public class LoginState : AssignState
    {
        public LoginState(RequestController requestController) : base(requestController)
        {
        }

        public override void OnMessageRequested(string userName)
        {
            Debug.Log(userName);
            FindUserName(userName, TryLogin);
        }

        void TryLogin(string userName, bool isAlreadyRegistered)
        {
            if (isAlreadyRegistered == false)
            {
                OnErrorLogRequested("로그인 실패", "등록되지 않은 유저입니다.");
            }
            else
            {
                _requestController.WebRequestComponent.OnOrderRequested<UserData>
                (userName, WebRequestComponent.DataType.User, OnLoginRequested, OnErrorLogRequested);
            }
        }

        void OnLoginRequested(UserData data)
        {
            UserManager.Instance.UserData = data;
            ReadSheetOrder order = new ReadSheetOrder("SolvedProblem_" + data.handle);
            _requestController.WebRequestComponent.OnOrderRequested<List<ProblemData>>(order, OnSolvedDataReceived, OnErrorLogRequested);
        }

        void OnSolvedDataReceived(List<ProblemData> datas)
        {
            // 이때 시트에서 푼 문제에 대한 정보 받아오기
            UserManager.Instance.ProblemDatas = datas;
            ReadSheetOrder order = new ReadSheetOrder("Register");
            _requestController.WebRequestComponent.OnOrderRequested<List<RegisterData>>(order, OnRegisterDataReceived, OnErrorLogRequested);
        }

        void OnRegisterDataReceived(List<RegisterData> registerData)
        {
            // 회원 가입한 날짜를 받아오기
            RegisterData data = registerData.Find(x => x.userName == UserManager.Instance.UserData.handle);
            UserManager.Instance.RegisterDate = data.registerDate;

            _requestController.FSM.SetState(RequestController.State.ChangingScene, "SelectScene");
        }
    }
}