using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOLVERS.Fsm;
using SOLVERS.Controller;
using SOLVERS.Manager;
using SOLVERS.DATA;

namespace SOLVERS.Fsm.RequestState
{
    public class AssignState : State
    {
        protected RequestController _requestController;

        public AssignState(RequestController requestController)
        {
            _requestController = requestController;
        }

        protected void FindUserName(string userName, System.Action<string, bool> OnDataReceived)
        {
            ContainRowOrder order = new ContainRowOrder("Register", "userName", userName);
            _requestController.WebRequestComponent.OnOrderRequested(order, OnDataReceived, OnErrorLogRequested);
        }

        void SpawnPopUp(string result, string log)
        {
            PopUp popUp = Object.Instantiate(_requestController.PopUpPrefab, _requestController.PopUpParent);
            popUp.Initialize(result, log);
        }

        protected void OnErrorLogRequested(string result, string log)
        {
            SpawnPopUp(result, log);
            _requestController.FSM.SetState(RequestController.State.Finish, "ErrorReceived");
        }

        protected void OnLogRequested(string result, string log)
        {
            Debug.Log("OnLogRequested");
            SpawnPopUp(result, log);
        }

        protected void GoToFinishState()
        {
            _requestController.FSM.SetState(RequestController.State.Finish, "GoToFinishState");
        }
    }
}