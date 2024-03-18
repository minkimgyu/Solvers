using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOLVERS.Fsm;
using SOLVERS.Fsm.RequestState;

namespace SOLVERS.Controller
{
    public class RequestController : MonoBehaviour
    {
        public enum State
        {
            Ready,
            Login,
            Register,
            Finish,
            ChangingScene,
        }

        [SerializeField] Transform _popUpParent;
        public Transform PopUpParent { get { return _popUpParent; } }

        [SerializeField] PopUp _popUpPrefab;
        public PopUp PopUpPrefab { get { return _popUpPrefab; } }


        protected StateMachine<State> _fsm;
        public StateMachine<State> FSM { get { return _fsm; } }


        WebRequestComponent _webRequestComponent;
        public WebRequestComponent WebRequestComponent { get { return _webRequestComponent; } }

        // Start is called before the first frame update
        public void Initialize()
        {
            InitializeFSM();
            _webRequestComponent = GetComponent<WebRequestComponent>();
        }

        public void OnLogin(string userName)
        {
            _fsm.OnLogin(userName);
        }

        public void OnRegister(string userName) 
        {
            _fsm.OnRegister(userName);
        }

        void InitializeFSM()
        {
            Dictionary<State, BaseState> states = new Dictionary<State, BaseState>()
            {
                {State.Ready, new ReadyState(this)},
                {State.Login, new LoginState(this)},
                {State.Register, new RegisterState(this)},
                {State.Finish, new FinishState(this)},
                {State.ChangingScene, new ChangingState(this)},
            };

            _fsm = new StateMachine<State>();
            _fsm.Initialize(states);
            _fsm.SetState(State.Ready);
        }
    }
}