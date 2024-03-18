using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOLVERS.Fsm;
using SOLVERS.Controller;

namespace SOLVERS.Fsm.RequestState
{
    public class FinishState : State
    {
        private RequestController _requestController;

        public FinishState(RequestController requestController)
        {
            _requestController = requestController;
        }

        public override void OnMessageRequested(string info)
        {
            Debug.Log(info);
            _requestController.FSM.SetState(RequestController.State.Ready, "GoToReadyState");
        }
    }
}