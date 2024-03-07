using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOLVERS.FSM;
using SOLVERS.FSM.STATE;
using SOLVERS.MANAGER;
using TMPro;
using UnityEngine.UI;

namespace SOLVERS.CONTROLLER
{
    public class StartSceneController : MonoBehaviour
    {
        public enum State
        {
            Entry,
            Login
        }

        [SerializeField] GameObject _startGo;
        public GameObject StartGo { get { return _startGo; } }

        [SerializeField] TMP_Text _pressTxt;
        public TMP_Text PressTxt { get { return _pressTxt; } }



        [SerializeField] GameObject _loginGo;
        public GameObject LoginGo { get { return _loginGo; } }

        [SerializeField] TMP_InputField _idInput;
        public TMP_InputField IdInput { get { return _idInput; } }

        [SerializeField] Button _backBtn;
        [SerializeField] Button _applyBtn;

        protected StateMachine<State> _fsm;
        public StateMachine<State> FSM { get { return _fsm; } }

        // Start is called before the first frame update
        void Start()
        {
            _backBtn.onClick.AddListener(() => OnBackToEntryRequested());
            _applyBtn.onClick.AddListener(() => OnLogInRequested()); // 싱글톤 받아서 로그인 기능 추가
            InitializeFSM();
        }

        void InitializeFSM()
        {
            Dictionary<State, BaseState> states = new Dictionary<State, BaseState>()
            {
                {State.Entry, new EntryState(this)},
                {State.Login, new LoginState(this)},
            };

            _fsm = new StateMachine<State>();
            _fsm.Initialize(states);
            _fsm.SetState(State.Entry);
        }

        void OnLogInRequested()
        {
            UserManager.Login(_idInput.text);
        }

        void OnBackToEntryRequested()
        {
            _fsm.BackToEntry();
        }

        // Update is called once per frame
        void Update()
        {
            _fsm.OnUpdate();
        }
    }
}