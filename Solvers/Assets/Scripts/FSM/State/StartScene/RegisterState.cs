using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOLVERS.Controller;
using SOLVERS.Manager;

namespace SOLVERS.FSM.STATE
{
    public class RegisterState : TaskState
    {
        public RegisterState(StartSceneController startSceneController, string taskLableTxt,
            string applyTxt, string switchStateTxt, StartSceneController.State switchState)
            : base (startSceneController, taskLableTxt, applyTxt, switchStateTxt, switchState)
        {
        }

        public override void OnClickApplyBtn()
        {
            // ���⿡ ��� ��� �߰�
            UserManager.Register(_startSceneController.IdInput.text);
        }
    }
}