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

* ### Google Sheet를 이용한 데이터 저장
    
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

* ### UnityWebRequest를 활용한 로그인, 회원 가입 기능

<div align="center">
	<a href="https://github.com/minkimgyu/Solvers/blob/994819e8a69321d16489c4647f3fdc4b05494375/Solvers/Assets/Scripts/WebRequestComponent.cs#L11">UnityWebRequest 코드 보러가기</a>
</div>

</br>
UnityWebRequest를 사용하여 GET, Post 방식으로 Google Sheet의 데이터를 불러오거나 전달할 수 있도록 구현하였습니다.
</br>
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
</br>
Google Apps Script에서 FSM을 사용하여 전달받은 데이터를 통해 Google Sheet의 값을 변경해줍니다.
</br>

* ### MVC 패턴 적용

  

* ### FSM을 활용한 Scene State 관리


    
<div align="center">FSM을 활용하여 각 Scene의 State를 관리했습니다.</div>
   
</details>

## 회고

* Google Sheet를 사용하여 데이터를 저장하고 불러오는 기능을 구현해보면서 Google Apps Script를 새롭게 배우게 되었습니다.
* 클라이언트에서 데이터를 전달하거나 불러오기 위해 UnityWebRequest를 사용해보았습니다. 처음 해보는 작업이라 많은 시행착오를 거쳤지만 앞으로 비슷한 프로젝트를 진행한다면 수월하게 진행할 수 있을 것 같습니다.
