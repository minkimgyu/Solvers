using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOLVERS.Controller;
using SOLVERS.DATA;
using System;

namespace SOLVERS.Fsm.RequestState
{
    public class RegisterState : AssignState
    {
        public RegisterState(RequestController requestController) : base(requestController)
        {
        }

        bool IsServerRefreshTime()
        {
            Debug.Log(DateTime.Now.Hour);
            return 23 <= DateTime.Now.Hour || DateTime.Now.Hour <= 0;
        }

        public override void OnMessageRequested(string userName)
        {
            if(IsServerRefreshTime())
            {
                OnErrorLogRequested("서버 점검", "11시부터 12시까지 서버점검 시간입니다.");
                return;
            }

            Debug.Log(userName);
            FindUserName(userName, TryRegister);
        }

        void TryRegister(string userName, bool isAlreadyRegistered)
        {
            if (isAlreadyRegistered == true)
            {
                OnErrorLogRequested("등록 실패", "이미 등록된 유저입니다.");
                return;
            }
            else
            {
                _requestController.WebRequestComponent.OnOrderRequested<UserData>
                    (userName, WebRequestComponent.DataType.User, OnRegisterRequested, OnErrorLogRequested);
            }
        }

        string ConvertDateTimeToString(DateTime dateTime) { return dateTime.ToString("yyyy.MM.dd"); }

        void OnRegisterRequested(UserData data)
        {
            string date = ConvertDateTimeToString(DateTime.Now);
            RegisterData registerData = new RegisterData(data.handle, date);

            ModifySheetOrder order = new InsertRowOrder<RegisterData>("Register", registerData);
            _requestController.WebRequestComponent.OnOrderRequested(order, AddSolvedDataRequested, data.handle, OnLogRequested);
        }

        void AddSolvedDataRequested(string userName)
        {
            AppendSolvedDataOrder order = new AppendSolvedDataOrder(userName);
            _requestController.WebRequestComponent.OnOrderRequested(order, OnErrorLogRequested);

            _requestController.FSM.SetState(RequestController.State.Finish, "GoToFinishState");
        }
    }
}