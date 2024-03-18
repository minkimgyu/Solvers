using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOLVERS.Controller;

namespace SOLVERS.Fsm.StartSceneState
{
    public class TaskState : State
    {
        protected StartSceneController _startSceneController;
        private string _taskLableTxt;
        private string _applyTxt;
        private string _switchStateTxt;
        private readonly StartSceneController.State _switchState;

        public TaskState(StartSceneController startSceneController, string taskLableTxt,
            string applyTxt, string switchStateTxt, StartSceneController.State switchState)
        {
            _startSceneController = startSceneController;
            _taskLableTxt = taskLableTxt;
            _applyTxt = applyTxt;
            _switchStateTxt = switchStateTxt;
            _switchState = switchState;
        }

        public override void OnClickBackBtn()
        {
            _startSceneController.FSM.SetState(StartSceneController.State.Entry);
        }

        public override void OnClickSwitchStateBtn()
        {
            _startSceneController.FSM.SetState(_switchState);
        }

        public override void OnClickApplyBtn()
        {
            // 여기에 등록 기능 추가
        }

        public override void OnStateEnter()
        {
            _startSceneController.TaskGo.SetActive(true);
            _startSceneController.BackBtnGo.gameObject.SetActive(true);
            _startSceneController.TaskLable.text = _taskLableTxt;
            _startSceneController.ApplyTxt.text = _applyTxt;
            _startSceneController.SwitchStateBtnTxt.text = _switchStateTxt;
        }

        public override void OnStateExit()
        {
            _startSceneController.IdInput.text = "";
            _startSceneController.TaskGo.SetActive(false);
        }
    }
}