using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOLVERS.CONTROLLER;

namespace SOLVERS.FSM.STATE
{
    public class LoginState : State
    {
        StartSceneController _startSceneController;

        public LoginState(StartSceneController startSceneController)
        {
            _startSceneController = startSceneController;
        }

        public override void BackToEntry() 
        {
            _startSceneController.FSM.SetState(StartSceneController.State.Entry);
        }

        public override void CheckStateChange()
        {

        }

        public override void OnStateEnter()
        {
            _startSceneController.LoginGo.SetActive(true);
        }

        public override void OnStateExit()
        {
            _startSceneController.IdInput.text = "";
            _startSceneController.LoginGo.SetActive(false);
        }
    }
}
