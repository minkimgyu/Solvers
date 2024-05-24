# Solvers
교내 동아리 운영을 위해 Unity를 사용하여 개발한 학습 관리 프로그램

## 프로젝트 소개
solved.ac API를 사용하여 백준 유저 정보를 불러와서 언제 어떤 문제를 풀었는지 확인할 수 있는 프로그램입니다.

## 개발 기간
24. 03 ~ 24. 06

## 인원
2명 (프로그래머 2명)

## 개발 환경
* Unity (C#)
* Google Apps Script (JavaScript)

## 기능 설명

<details>
	<summary>Google Sheet를 이용한 데이터 저장</summary>
    
   트리거 내용 넣기
   
</details>


<details>
	<summary>로그인, 회원 가입 및 데이터 불러오기</summary>
    
   내용을 적어주세요.
   
</details>



<details>
	<summary>MVC 패턴 적용</summary>
    
   내용을 적어주세요.
   
</details>


<details>
	<summary>FSM을 활용한 Scene State 관리</summary>
    

``` cs

public enum State
{
    Entry,
    Login,
    Register
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

```
<div align="center">FSM을 활용하여 각 Scene의 State를 효율적으로 관리했습니다.</div>
   
</details>

## 회고

* Google Sheet를 사용하여 데이터를 저장하고 불러오는 기능을 구현해보면서 Google Apps Script를 새롭개 배우게 되었습니다.
* 클라이언트에서 데이터를 전달하거나 불러오기 위해 UnityWebRequest를 사용해보았습니다. 처음 해보는 작업이라 많은 시행착오를 거쳤지만 앞으로 비슷한 프로젝트를 진행한다면 수월하게 진행할 수 있을 것 같습니다.
