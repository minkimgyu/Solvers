using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOLVERS.Fsm
{
    abstract public class State : BaseState
    {
        public override void OnMessageRequested(string info) { }

        public override void OnClickBackBtn() { }
        public override void OnClickSwitchStateBtn() { }
        public override void OnClickApplyBtn() { }

        // RequestController
        public override void OnLoginRequested(string userName) { }
        public override void OnRegisterRequested(string userName) { }


        public override void CheckStateChange() { }
        public override void OnStateEnter() { }
        public override void OnStateUpdate() { }
        public override void OnStateExit() { }
    }

    abstract public class BaseState
    {
        public abstract void OnMessageRequested(string info);

        public abstract void OnClickBackBtn();
        public abstract void OnClickSwitchStateBtn();
        public abstract void OnClickApplyBtn();

        // RequestController
        public abstract void OnLoginRequested(string userName);
        public abstract void OnRegisterRequested(string userName);


        public abstract void CheckStateChange();
        public abstract void OnStateEnter();
        public abstract void OnStateUpdate();
        public abstract void OnStateExit();
    }

    public class StateMachine<T>
    {
        Dictionary<T, BaseState> _stateDictionary = new Dictionary<T, BaseState>();

        //현재 상태를 담는 프로퍼티.
        BaseState _currentState;
        BaseState _previousState;

        public void Initialize(Dictionary<T, BaseState> stateDictionary)
        {
            _currentState = null;
            _previousState = null;

            _stateDictionary = stateDictionary;
        }

        public void OnUpdate()
        {
            if (_currentState == null) return;
            _currentState.OnStateUpdate();
            _currentState.CheckStateChange();
        }


        public void OnLogin(string userName)
        {
            if (_currentState == null) return;
            _currentState.OnLoginRequested(userName);
        }

        public void OnRegister(string userName)
        {
            if (_currentState == null) return;
            _currentState.OnRegisterRequested(userName);
        }


        public void OnClickBackBtn()
        {
            if (_currentState == null) return;
            _currentState.OnClickBackBtn();
        }

        public void OnClickSwitchStateBtn()
        {
            if (_currentState == null) return;
            _currentState.OnClickSwitchStateBtn();
        }

        public void OnClickApplyBtn()
        {
            if (_currentState == null) return;
            _currentState.OnClickApplyBtn();
        }

        public bool RevertToPreviousState()
        {
            return ChangeState(_previousState);
        }

        #region SetState

        public bool SetState(T stateName)
        {
            return ChangeState(_stateDictionary[stateName]);
        }

        public bool SetState(T stateName, string info)
        {
            return ChangeState(_stateDictionary[stateName], info);
        }

        #endregion


        #region ChangeState

        bool ChangeState(BaseState state)
        {
            if (_stateDictionary.ContainsValue(state) == false) return false;

            if (_currentState == state) // 같은 State로 전환하지 못하게 막기
            {
                return false;
            }

            if (_currentState != null) //상태가 바뀌기 전에, 이전 상태의 Exit를 호출
                _currentState.OnStateExit();

            _previousState = _currentState;

            _currentState = state;


            if (_currentState != null) //새 상태의 Enter를 호출한다.
            {
                _currentState.OnStateEnter();
            }

            return true;
        }

        bool ChangeState(BaseState state, string info)
        {
            if (_stateDictionary.ContainsValue(state) == false) return false;

            if (_currentState == state) // 같은 State로 전환하지 못하게 막기
            {
                return false;
            }

            if (_currentState != null) //상태가 바뀌기 전에, 이전 상태의 Exit를 호출
                _currentState.OnStateExit();

            _previousState = _currentState;

            _currentState = state;
            _currentState.OnMessageRequested(info);

            if (_currentState != null) //새 상태의 Enter를 호출한다.
            {
                _currentState.OnStateEnter();
            }

            return true;
        }

        #endregion
    }
}