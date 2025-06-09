# 🧩 Solvers

교내 동아리 운영을 위해 Unity를 사용하여 개발한 학습 관리 프로그램입니다.

solved.ac API를 사용하여 백준 유저 정보를 불러와서 언제 어떤 문제를 풀었는지 확인할 수 있습니다.

<img src="https://github.com/minkimgyu/Solvers/assets/48249824/ada439d6-54d6-42ee-8473-aa3db6344365" width="70%" height="70%"/>

## 🗓️ 개발 기간
2024년 3월 ~ 2024년 6월

## 🧑‍🤝‍🧑 인원
- 총 2명 (클라이언트 프로그래머 2명)

## 🛠️ 개발 환경
* Unity (C#)
* Google Apps Script (JavaScript)

---

## ☁️ Google Apps Script를 활용하여 데이터 저장 기능 구현

Google Apps Script를 활용해 solved.ac API에서 유저 데이터를 받아와서 Google Sheet에 저장하는 작업을 진행했습니다.

<img src="https://github.com/minkimgyu/Solvers/assets/48249824/0ad5f5d2-416b-4fb9-8dff-cb302cda42f8" width="90%" height="90%"/>
</br>

```js
function ParsingSolvedData(userName, page)
{
  // url을 통해 데이터를 불러온다.
  let url = "https://solved.ac/api/v3/search/problem?query=solved_by%3A" + userName;
  if(page) url += "&page=" + page; // GET URL
  
  let response = UrlFetchApp.fetch(url);
  let data = JSON.parse(response.getContentText());
  return data
}
```
</br>

## 🔑 UnityWebRequest를 활용한 로그인, 회원 가입 기능 구현

UnityWebRequest를 사용하여 GET, Post 방식으로 Google Sheet의 데이터를 불러오거나 전달할 수 있도록 구현하였습니다.

<div align="center">
	<a href="https://github.com/minkimgyu/Solvers/blob/994819e8a69321d16489c4647f3fdc4b05494375/Solvers/Assets/Scripts/WebRequestComponent.cs#L11">UnityWebRequest 코드 보러가기</a>
</div>
</br>

```js
function doPost(e)
{
  var data = JSON.parse(e.parameter.json);
  var sheet = sheetId.getSheetByName(data.sheetName);

  switch(data.type)
  {
    case ORDER.DELETEROW : return DeleteRow(sheet, data.title, data.value, data.type);
    case ORDER.INSERTROW : return InsertRow(sheet, data);
    case ORDER.CHANGEROW : return ChangeRow(sheet, data.title, data.beforeValue, data.afterValue, data.type);
    case ORDER.CONTAINROW : return ContainRow(sheet, data.title, data.value);
    case ORDER.READSHEET : return ReadSheet(sheet);
    case ORDER.ADDSOLVEDDATA : return AddSolvedData(data.userName);
  }
}
```

Google Apps Script에서 FSM을 사용하여 전달받은 데이터를 통해 Google Sheet의 값을 변경해줍니다.
</br>

## 📅 MVC 패턴을 활용하여 달력 시스템 개발
</br>
<div align="center">
	<img src="https://github.com/user-attachments/assets/0870b37a-fbb4-48b5-853c-b3780d7ca294" width="45%" height="45%"/>
	</br>
</div>

<div align="center">
	<a href="https://github.com/minkimgyu/Solvers/blob/6cff21985dd3084fbb19dcda73d62f201c16f4d0/Solvers/Assets/Scripts/Calendar/CalendarController.cs#L10">Model 코드 보러가기</a>
	</br>
	<a href="https://github.com/minkimgyu/Solvers/blob/26d65a638c5ab4a70e8b0aa29d9516227f8584ae/Solvers/Assets/Scripts/Calendar/DateView.cs#L10">View 코드 보러가기</a>
	</br>
	<a href="https://github.com/minkimgyu/Solvers/blob/26d65a638c5ab4a70e8b0aa29d9516227f8584ae/Solvers/Assets/Scripts/Calendar/CalendarController.cs#L10C14-L10C33">Controller 코드 보러가기</a>
	</br>
	</br>
	Calendar 구현 시 View, Controller, Model을 나누어 결합도를 낮추었습니다.
</div>
</br>

## 🕹️ FSM을 사용하여 RequestController 개발

<div align="center">
	<img src="https://github.com/user-attachments/assets/33f93513-7850-4cf3-a3d1-be9a2bdb19c1" width="45%" height="45%"/>
	</br>
</div>
<div align="center">
	<a href="https://github.com/minkimgyu/Solvers/blob/3cf843ecc21712c45f67cd855c3b683f4e11a120/Solvers/Assets/Scripts/Controller/RequestController.cs#L9">코드 보러가기</a>
	</br>
	FSM을 활용하여 사용자의 입력을 처리하는 RequestController을 개발했습니다.
</div>

</details>

---

## 💭 회고

* Google Sheet를 사용하여 데이터를 저장하고 불러오는 기능을 구현해보면서 Google Apps Script에 대해 새롭게 배우게 되었습니다.
* 클라이언트에서 데이터를 전달하거나 불러오기 위해 UnityWebRequest를 사용해보았습니다. 처음 해보는 작업이라 많은 시행착오를 거쳤지만 앞으로 비슷한 프로젝트를 진행한다면 수월하게 진행할 수 있을 것 같습니다.
