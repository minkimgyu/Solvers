using SOLVERS.Fsm;
using SOLVERS.Fsm.StartSceneState;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SOLVERS.Controller
{
    public class StartSceneController : MonoBehaviour
    {
        public enum State
        {
            Entry,
            Login,
            Register
        }

        [SerializeField] GameObject _startGo;
        public GameObject StartGo { get { return _startGo; } }

        [SerializeField] TMP_Text _pressTxt;
        public TMP_Text PressTxt { get { return _pressTxt; } }

        [SerializeField] Button _backBtn;
        public GameObject BackBtnGo { get { return _backBtn.gameObject; } }


        [SerializeField] GameObject _taskGo;
        public GameObject TaskGo { get { return _taskGo; } }


        [SerializeField] TMP_Text _taskLable;
        public TMP_Text TaskLable { get { return _taskLable; } }

        [SerializeField] TMP_InputField _idInput;
        public TMP_InputField IdInput { get { return _idInput; } }

        [SerializeField] Button _applyBtn;

        [SerializeField] TMP_Text _applyTxt;
        public TMP_Text ApplyTxt { get { return _applyTxt; } }


        [SerializeField] Button _switchStateBtn;

        [SerializeField] TMP_Text _switchStateBtnTxt;
        public TMP_Text SwitchStateBtnTxt { get { return _switchStateBtnTxt; } }

        protected StateMachine<State> _fsm;
        public StateMachine<State> FSM { get { return _fsm; } }

        // Start is called before the first frame update
        void Start()
        {
            _backBtn.onClick.AddListener(() => OnClickBackBtnRequested());
            _applyBtn.onClick.AddListener(() => OnClickApplyBtnRequested()); // 싱글톤 받아서 로그인 기능 추가

            _switchStateBtn.onClick.AddListener(() => OnClickSwitchStateBtnRequested()); // 싱글톤 받아서 로그인 기능 추가
            InitializeFSM();
        }

        void InitializeFSM()
        {
            Dictionary<State, BaseState> states = new Dictionary<State, BaseState>()
            {
                {State.Entry, new EntryState(this)},
                {State.Login, new LoginState(this, "Login", "Sign In", "Register", State.Register)},
                {State.Register, new RegisterState(this, "Register", "Sign Up", "Login", State.Login)},
            };

            _fsm = new StateMachine<State>();
            _fsm.Initialize(states);
            _fsm.SetState(State.Entry);
        }

        void OnClickSwitchStateBtnRequested()
        {
            _fsm.OnClickSwitchStateBtn();
        }

        // 이 부분을 fsm으로 빼주기
        void OnClickApplyBtnRequested()
        {
            _fsm.OnClickApplyBtn();

           
        }

        void OnClickBackBtnRequested()
        {
            _fsm.OnClickBackBtn();
        }

        // Update is called once per frame
        void Update()
        {
            _fsm.OnUpdate();
        }
    }
}