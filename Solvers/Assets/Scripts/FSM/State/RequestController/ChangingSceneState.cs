using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOLVERS.Controller;
using UnityEngine.SceneManagement;

namespace SOLVERS.Fsm.RequestState
{
    public class ChangingState : State
    {
        private RequestController _requestController;

        public ChangingState(RequestController requestController)
        {
            _requestController = requestController;
        }

        public override void OnMessageRequested(string info)
        {
            Debug.Log(info);
            _requestController.FSM.SetState(RequestController.State.Ready, "GoToReadyState");
            SceneManager.LoadScene(info);
        }
    }
}