using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOLVERS.Fsm;
using SOLVERS.Controller;

namespace SOLVERS.Fsm.RequestState
{
    public class ReadyState : State
    {
        private RequestController _requestController;

        public ReadyState(RequestController requestController)
        {
            _requestController = requestController;
        }

        public override void OnMessageRequested(string info)
        {
            Debug.Log(info);
        }

        public override void OnLoginRequested(string userName)
        {
            _requestController.FSM.SetState(RequestController.State.Login, userName);
        }

        public override void OnRegisterRequested(string userName)
        {
            _requestController.FSM.SetState(RequestController.State.Register, userName);
        }
    }
}