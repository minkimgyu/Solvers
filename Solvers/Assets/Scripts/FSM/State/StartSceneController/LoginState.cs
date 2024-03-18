using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOLVERS.Controller;
using SOLVERS.Manager;

namespace SOLVERS.Fsm.StartSceneState
{
    public class LoginState : TaskState
    {
        public LoginState(StartSceneController startSceneController, string taskLableTxt,
            string applyTxt, string switchStateTxt, StartSceneController.State switchState)
            : base(startSceneController, taskLableTxt, applyTxt, switchStateTxt, switchState)
        {
        }

        public override void OnClickApplyBtn()
        {
            // ���⿡ �α��� ��� �߰�
            UserManager.Login(_startSceneController.IdInput.text);
        }
    }
}
