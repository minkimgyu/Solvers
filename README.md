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

```js
function ParsingSolvedData(userName, page)
{
  let url = "https://solved.ac/api/v3/search/problem?query=solved_by%3A" + userName;
  if(page) url += "&page=" + page; // GET URL
  
  let response = UrlFetchApp.fetch(url);
  let data = JSON.parse(response.getContentText());
  return data
}

function CreateSolvedData(userName)
{ 
  // 해당 시트가 있는지 확인하고 없으면 생성해서 넣어주기
  let isContaining = IsContainingSheet(userName);
  if(isContaining == false) CreateSolvedProblemSheet(userName);

  let datas = [];

  var jsonData = ParsingSolvedData(userName);
  var pages = Math.floor((jsonData.count - 1) / 50) + 1;
  
  var nowPage = 1;
  while(pages >= nowPage) // 모든 페이지를 읽어온다.
  {
    let solvedData = ParsingSolvedData(userName, nowPage);
    for(let i = 0; i<solvedData.items.length; i++)
    {
      let data = BuildProblemData(solvedData.items[i]);
	    datas.push(data);
    }
    nowPage++;
  }

  var sheet = sheetId.getSheetByName(SheetForeword + userName);

  if(isContaining == false) InsertRectToSheet(sheet, datas, ProblemDataType); // 처음부터 데이터를 삽입한다.
  else UpdateSheetData(sheet, datas, ProblemDataType) // 기존 데이터를 업데이트 해준다.
}
```



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
    


<div align="center">FSM을 활용하여 각 Scene의 State를 관리했습니다.</div>
   
</details>

## 회고

* Google Sheet를 사용하여 데이터를 저장하고 불러오는 기능을 구현해보면서 Google Apps Script를 새롭게 배우게 되었습니다.
* 클라이언트에서 데이터를 전달하거나 불러오기 위해 UnityWebRequest를 사용해보았습니다. 처음 해보는 작업이라 많은 시행착오를 거쳤지만 앞으로 비슷한 프로젝트를 진행한다면 수월하게 진행할 수 있을 것 같습니다.
